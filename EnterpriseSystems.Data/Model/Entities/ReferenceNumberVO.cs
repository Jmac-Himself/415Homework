using System;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class ReferenceNumberVO
    {
        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityID { get; set; }
        public string SELURefNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUID { get; set; }
        public string CreatedCode { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUID { get; set; }
        public string LastUpdatedCode { get; set; }
    }
}
