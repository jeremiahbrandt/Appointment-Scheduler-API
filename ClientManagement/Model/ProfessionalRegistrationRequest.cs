using AppointmentManagerApi.Data;

namespace AppointmentManagerApi.Model
{
    public class ProfessionalRegistrationRequest
    {
        public string FirebaseUid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email;
    }
}
