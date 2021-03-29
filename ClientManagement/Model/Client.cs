using ClientManagement.Model;

namespace AppointmentManagerApi.Model
{
    public class Client
    {
        public Account Account { get; set; }
        public string Uid { get; set; }
        public Appointment[] Appointments { get; set; }
        public ProfessionalModel[] FavoriteProfessionals { get; set; }
    }
}
