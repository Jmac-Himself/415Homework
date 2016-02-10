using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Mappers
{
    public class AppointmentMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<AppointmentVO> AppointmentHydrater { get; set; }
        IQuery NewQuery;
        DataTable dataTable;

        public AppointmentMapper(IDatabase database, IHydrater<AppointmentVO> appointmentHydrater)
        {
            Database = database;
            AppointmentHydrater = appointmentHydrater;
        }
        public IEnumerable<AppointmentVO> GetAppointmentsByCustomerRequest(CustomerRequestVO CustomerRequest)
        {
            Database.CreateQuery("SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I");
            NewQuery.AddParameter(CustomerRequest, "@CUS_REQ_I");
            dataTable = Database.RunSelect(NewQuery);
            return AppointmentHydrater.Hydrate(dataTable);

        }
        public IEnumerable<AppointmentVO> GetAppointmentsByStop(StopVO Stop)
        {
            Database.CreateQuery("SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I");
            NewQuery.AddParameter(Stop, "@REQ_ETY_OGN_I");
            dataTable = Database.RunSelect(NewQuery);
            return AppointmentHydrater.Hydrate(dataTable);
        }
    }
}
