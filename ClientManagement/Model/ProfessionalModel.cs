using AppointmentManagerApi.Data;
using ClientManagement.Model;
using System.Collections.Generic;

namespace AppointmentManagerApi.Model
{
    public class ProfessionalModel : GetProfessionalResponse
    {
        public ProfessionalModel()
        {

        }
        public ProfessionalModel(GetProfessionalResponse getProfessionalResponse)
        {
            this.FirebaseUid = getProfessionalResponse.FirebaseUid;
            this.FirstName = getProfessionalResponse.FirstName;
            this.LastName = getProfessionalResponse.LastName;
            this.Occupation = getProfessionalResponse.Occupation;
            this.ShareableCode = getProfessionalResponse.ShareableCode;
            this.StreetNumber = getProfessionalResponse.StreetNumber;
            this.StreetName = getProfessionalResponse.StreetName;
            this.City = getProfessionalResponse.City;
            this.State = getProfessionalResponse.State;
            this.ZipCode = getProfessionalResponse.ZipCode;
        }

        public string Email;
        public IList<GetProfessionalAppointmentsResponse> Appointments { get; set; }
        public IList<GetProfessionalTimeSlotsResponse> OpenTimeSlots { get; set; }
    }
}
