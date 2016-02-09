using EnterpriseSystems.Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class StopHydrater : IHydrater<StopVO>
    {
        public IEnumerable<StopVO> Hydrate(DataTable dataTable)
        {
            var Stops = new List<StopVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var Stop = HydrateEntity(dataRow);
                    Stops.Add(Stop);
                }
            }

            return Stops;
        }

        private StopVO HydrateEntity(DataRow dataRow)
        {
            var Stop = new StopVO
            {
                Identity = (int)dataRow["REQ_ETY_OGN_I"],
                EntityName = dataRow["ETY_NM"].ToString(),
                EntityID = (int)dataRow["ETY_KEY_I"],
                RoleType = dataRow["SLU_PTR_RL_TYP_C"].ToString(),
                StopNumber = dataRow["STP_NBR"].ToString(),
                CustomerAlias = dataRow["CUS_SIT_ALS"].ToString(),
                OrganizationName = dataRow["OGN_NM"].ToString(),
                AddressLine1 = dataRow["ADR_LNE_1"].ToString(),
                AddressLine2 = dataRow["ADR_LNE_2"].ToString(),
                CityName = dataRow["ADR_CTY_NM"].ToString(),
                StateCode = dataRow["ADR_ST_PROV_C"].ToString(),
                CountryCode = dataRow["ADR_CRY_C"].ToString(),
                PostalCode = dataRow["ADR_PST_C_SRG"].ToString(),
                CreatedDate = (DateTime)dataRow["CRT_S"],
                CreatedUID = dataRow["CRT_UID"].ToString(),
                CreatedCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime)dataRow["LST_UPD_S"],
                LastUpdatedUID = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedCode = dataRow["LST_UPD_PGM_C"].ToString()
            };

            return Stop;
        }
    }
}
