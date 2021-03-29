using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    class GetClientAppointmentsResponse
    {
        public string AppointmentId { get; set; }
        public string ProfessionalFirstName { get; set; }
        public string ProfessionalLastName { get; set; }
        public string ProfessionalEmailAddress { get; set; }
        public string ProfessionalOccupation { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentDescription { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ProfessionalUid { get; set; }
        public string ClientUid { get; set; }


    }
}
