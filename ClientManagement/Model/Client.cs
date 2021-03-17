using ClientManagement.Model;

namespace AppointmentManagerApi.Model
{
    class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Uid { get; set; }
        Appointment[] Appointments { get; set; }
        ProfessionalModel[] FavoriteProfessional { get; set; }
    }
}
