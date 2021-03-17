using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    class GetProfessionalAppointmentsResponse
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Name { get; set; }
        public string ClientUid { get; set; }
    }
}
