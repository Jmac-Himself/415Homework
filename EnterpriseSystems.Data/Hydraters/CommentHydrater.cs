using EnterpriseSystems.Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Hydraters
{
    public class CommentHydrater:IHydrater<CommentVO>
    {
        public IEnumerable<CommentVO> Hydrate(DataTable dataTable)
        {
            var Comments = new List<CommentVO>();

            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var Comment = HydrateEntity(dataRow);
                    Comments.Add(Comment);
                }
            }
            return Comments;
        }
        private CommentVO HydrateEntity(DataRow dataRow)
        {
            var Comment = new CommentVO
            {
                Identity = (int)dataRow["REQ_ETY_CMM_I"],
                EntityName = dataRow["ETY_NM"].ToString(),
                EntityID = (int)dataRow["ETY_KEY_I"],
                SequenceNum = (int)dataRow["SEQ_NBR"],
                CommentType = dataRow["CMM_TYP"].ToString(),
                Comment = dataRow["CMM_TXT"].ToString(),
                CreatedDate = (DateTime)dataRow["CRT_S"],
                CreatedUID = dataRow["CRT_UID"].ToString(),
                CreatedCode = dataRow["CRT_PGM_C"].ToString(),
                LastUpdatedDate = (DateTime)dataRow["LST_UPD_S"],
                LastUpdatedUID = dataRow["LST_UPD_UID"].ToString(),
                LastUpdatedCode = dataRow["LST_UPD_PGM_C"].ToString()
            };
            return Comment;
        }
    }
}
