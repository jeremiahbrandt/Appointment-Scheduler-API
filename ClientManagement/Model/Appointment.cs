namespace AppointmentManagerApi.Model
{
    public class Appointment
    {
        public ProfessionalModel Professional { get; set; }
        public Client Client { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
