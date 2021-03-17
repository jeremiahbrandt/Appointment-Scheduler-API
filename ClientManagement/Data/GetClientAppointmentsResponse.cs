using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    class GetClientAppointmentsResponse
    {
        public string AppointmentId { get; set; }
        public string ClientUid { get; set; }
        public string ProfessionalUid { get; set; }
        public string TimeSlotId { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentDescription { get; set; }
        public string AppointmentLocation { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
