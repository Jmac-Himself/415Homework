using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Mappers
{
    public class ReferenceNumberMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<ReferenceNumberVO> ReferenceNumberHydrater { get; set; }
        IQuery NewQuery;
        DataTable dataTable;

        public ReferenceNumberMapper(IDatabase database, IHydrater<ReferenceNumberVO> referenceNumberHydrater)
        {
            Database = database;
            ReferenceNumberHydrater = referenceNumberHydrater;
        }

        public IEnumerable<ReferenceNumberVO> GetReferenceNumbersByCustomerRequest(CustomerRequestVO customerRequest)
        {
            Database.CreateQuery("SELECT * FROM REQ_ETY_REF_NBR WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I");
            NewQuery.AddParameter(customerRequest, "@CUS_REQ_I");
            dataTable = Database.RunSelect(NewQuery);
            return ReferenceNumberHydrater.Hydrate(dataTable);
        }
    }
}
