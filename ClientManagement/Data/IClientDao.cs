using AppointmentManagerApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    public interface IClientDao
    {
        public void AddClient(GetClientResponse client);
        public void AddClientFavorite(string clientUid, string professionalUid);
        public GetClientResponse GetClient(string uid);
        public IList<GetClientFavoritesResponse> GetClientFavorites(string uid);
        public IList<GetClientAppointmentsResponse> GetClientAppointments(string uid);
        public void UpdateClient(GetClientResponse client);
        public void RemoveClient(string uid);
        public void RemoveClientFavorite(string clientUid, string professionalUid);
    }
}
