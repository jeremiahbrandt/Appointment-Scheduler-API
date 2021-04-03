using AppointmentManagerApi.Data;
using System.Collections.Generic;

namespace AppointmentManagerApi.Model
{
    public class ClientModel : GetClientResponse
    {
        public ClientModel()
        {

        }

        public ClientModel(GetClientResponse getClientResponse)
        {
            this.FirebaseUid = getClientResponse.FirebaseUid;
            this.FirstName = getClientResponse.FirstName;
            this.LastName = getClientResponse.LastName;
        }
        public string Email { get; set; }
        public IList<GetClientAppointmentsResponse> Appointments { get; set; }
        public IList<GetClientFavoritesResponse> FavoriteProfessionals { get; set; }
    }
}
