namespace AppointmentManagerApi.Model
{
    class Appointment
    {
        ProfessionalModel Professional { get; set; }
        Client Client { get; set; }
        TimeSlot TimeSlot { get; set; }
        Location Location { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
