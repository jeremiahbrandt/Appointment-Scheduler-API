using AppointmentManagerApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    public interface IClientDao
    {
        public GetClientResponse AddClient(ClientModel client);
        public GetClientResponse AddClientFavorite(string clientUid, string professionalUid);
        public GetClientResponse GetClient(string uid);
        public IList<GetClientFavoritesResponse> GetClientFavorites(string uid);
        public IList<GetClientAppointmentsResponse> GetClientAppointments(string uid);
        public GetClientResponse UpdateClient(ClientModel client);
        public bool RemoveClient(string uid);
        public GetClientResponse RemoveClientFavorite(string clientUid, string professionalUid);
    }
}
