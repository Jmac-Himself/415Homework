using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Data.Mappers
{
    public class ReferenceNumberMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<ReferenceNumberVO> ReferenceNumberHydrater { get; set; }

        public ReferenceNumberMapper(IDatabase database, IHydrater<ReferenceNumberVO> referenceNumberHydrater)
        {
            Database = database;
            ReferenceNumberHydrater = referenceNumberHydrater;
        }

        public ReferenceNumberVO GetReferenceNumbersByCustomerRequest(ReferenceNumberVO ReferenceNumber)
        {
            throw new NotImplementedException();
        }
    }
}
