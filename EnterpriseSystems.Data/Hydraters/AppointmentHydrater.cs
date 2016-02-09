using EnterpriseSystems.Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class AppointmentHydrater : IHydrater<AppointmentVO>
    {
        public IEnumerable<AppointmentVO> Hydrate(DataTable dataTable)
        {
            var Appointments = new List<AppointmentVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var Appointment = HydrateEntity(dataRow);
                    Appointments.Add(Appointment);
                }
            }

            return Appointments;
        }
        private AppointmentVO HydrateEntity(DataRow dataRow)
        {
            var Appointment = new AppointmentVO
            {
                Identity = (int)dataRow["REQ_ETY_SCH_I"],
                EntityName = dataRow["ETY_NM"].ToString(),
                EntityID = (int)dataRow["ETY_KEY_I"],
                SequenceNum = (int)dataRow["SEQ_NBR"],
                FunctionType = dataRow["SCH_FUN_TYP"].ToString(),
                AppointmentStart = (DateTime)dataRow["BEG_S"],
                AppointmentEnd = (DateTime)dataRow["END_S"],
                Timezone = dataRow["TZ_TYP_DSC"].ToString(),
                Status = dataRow["PRS_STT"].ToString(),
                CreatedDate = (DateTime)dataRow["CRT_S"],
                CreatedUID = dataRow["CRT_UID"].ToString(),
                CreatedCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime)dataRow["LST_UPD_S"],
                LastUpdatedUID = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedCode = dataRow["LST_UPD_PGM_C"].ToString()
            };
            return Appointment;
        }
    }
}
