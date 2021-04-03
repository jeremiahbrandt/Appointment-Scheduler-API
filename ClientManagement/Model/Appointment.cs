using ClientManagement.Model;

namespace AppointmentManagerApi.Model
{
    public class Appointment
    {
        public Account Professional { get; set; }
        public Account Client { get; set; }
        public TimeSlotModel TimeSlot { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
