using EnterpriseSystems.Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class ReferenceNumberHydrater:IHydrater<ReferenceNumberVO>
    {
        public IEnumerable<ReferenceNumberVO> Hydrate(DataTable dataTable)
        {
            var ReferenceNumbers = new List<ReferenceNumberVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var ReferenceNumber = HydrateEntity(dataRow);
                    ReferenceNumbers.Add(ReferenceNumber);
                }
            }

            return ReferenceNumbers;
        }

        private ReferenceNumberVO HydrateEntity(DataRow dataRow)
        {
            var ReferenceNumber = new ReferenceNumberVO
            {
                Identity = (int)dataRow["REQ_ETY_REF_NBR_I"],
                EntityName = dataRow["ETY_NM"].ToString(),
                EntityID = (int)dataRow["ETY_KEY_I"],
                SELURefNumber = dataRow["SLU_REF_NBR_TYP"].ToString(),
                ReferenceNumber = dataRow["REF_NBR"].ToString(),
                CreatedDate = (DateTime)dataRow["CRT_S"],
                CreatedUID = dataRow["CRT_UID"].ToString(),
                CreatedCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime)dataRow["LST_UPD_S"],
                LastUpdatedUID = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedCode = dataRow["LST_UPD_PGM_C"].ToString()
            };

            return ReferenceNumber;
        }

    }
}
