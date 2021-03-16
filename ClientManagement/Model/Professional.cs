using ClientManagement.Model;

namespace AppointmentManagerApi.Model
{
    class Professional
    {
        Account Account { get; set; }
        string Occupation { get; set; }
        Location Location { get; set; }
    }
}
