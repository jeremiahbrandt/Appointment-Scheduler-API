using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Model
{
    public class AppointmentRequest
    {
        public string ClientFirebaseUid { get; set; }
        public int TimeSlotId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
