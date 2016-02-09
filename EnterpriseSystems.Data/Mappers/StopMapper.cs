using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;

namespace EnterpriseSystems.Data.Mappers
{
    public class StopMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<StopVO> StopHydrater { get; set; }

        public StopMapper(IDatabase database, IHydrater<StopVO> stopHydrater)
        {
            Database = database;
            StopHydrater = stopHydrater;
        }

        public StopVO GetStopsByCustomerRequest(StopVO Stop)
        {
            throw new NotImplementedException();
        }
    }
}
