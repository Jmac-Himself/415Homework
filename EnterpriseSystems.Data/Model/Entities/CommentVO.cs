using System;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class CommentVO
    {
        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityID { get; set; }
        public int SequenceNum { get; set; }
        public string CommentType { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUID { get; set; }
        public string CreatedCode { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUID { get; set; }
        public string LastUpdatedCode { get; set; }
    }
}
