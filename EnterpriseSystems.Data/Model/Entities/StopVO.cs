using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class StopVO
    {
        public StopVO()
        {
            Appointments = new List<AppointmentVO>();
            Comments = new List<CommentVO>();
        }
        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityID { get; set; }
        public string RoleType { get; set; }
        public string StopNumber { get; set; }
        public string CustomerAlias { get; set; }
        public string OrganizationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUID { get; set; }
        public string CreatedCode { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedUID { get; set; }
        public string LastUpdatedCode { get; set; }

        public List<AppointmentVO> Appointments { get; set; }
        public List<CommentVO> Comments { get; set; }
    }
}
