using System;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class AppointmentVO
    {
        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityID { get; set; }
        public int SequenceNum { get; set; }
        public string FunctionType { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public string Timezone { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUID { get; set; }
        public string CreatedCode { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUID { get; set; }
        public string LastUpdatedCode { get; set; }
    }
}
