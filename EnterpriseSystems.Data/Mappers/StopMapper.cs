using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;
using System.Data;
using System.Collections.Generic;

namespace EnterpriseSystems.Data.Mappers
{
    public class StopMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<StopVO> StopHydrater { get; set; }
        IQuery NewQuery;
        DataTable dataTable;

        public StopMapper(IDatabase database, IHydrater<StopVO> stopHydrater)
        {
            Database = database;
            StopHydrater = stopHydrater;
        }

        public IEnumerable<StopVO> GetStopsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            Database.CreateQuery("SELECT * FROM REQ_ETY_OGN WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I"");
            NewQuery.AddParameter(customerRequest, "@CUS_REQ_I");
            dataTable = Database.RunSelect(NewQuery);
            return StopHydrater.Hydrate(dataTable);
        }
    }
}
