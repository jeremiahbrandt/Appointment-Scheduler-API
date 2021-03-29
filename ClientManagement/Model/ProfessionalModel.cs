using ClientManagement.Model;

namespace AppointmentManagerApi.Model
{
    public class ProfessionalModel
    {
        public string Occupation { get; set; }
        public Account Account { get; set; }
        public Location Location { get; set; }
        public Appointment[] Appointments { get; set; }
        public TimeSlot[] OpenTimeSlots { get; set; }
    }
}
