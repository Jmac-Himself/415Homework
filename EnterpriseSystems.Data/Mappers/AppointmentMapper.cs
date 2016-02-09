using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Data.Mappers
{
    public class AppointmentMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<AppointmentVO> AppointmentHydrater { get; set; }

        public AppointmentMapper(IDatabase database, IHydrater<AppointmentVO> appointmentHydrater)
        {
            Database = database;
            AppointmentHydrater = appointmentHydrater;
        }
        public IEnumerable<AppointmentVO> GetAppointmentsByCustomerRequest(AppointmentVO Appointment)
        {
            throw new NotImplementedException();
        }
        public AppointmentVO GetAppointmentsByStop(AppointmentVO Appointment)
        {
            throw new NotImplementedException();
        }
    }
}
