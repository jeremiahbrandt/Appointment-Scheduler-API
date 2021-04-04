using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using ClientManagement;
using ClientManagement.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AppointmentManagerApi.Services
{
    class ClientService
    {
        private static IClientDao clientDao;
        private static ICalendarDao calendarDao;

        public ClientService()
        {
            if(clientDao == null)
            {
                clientDao = new ClientDao();
            }
            if (calendarDao == null)
            {
                calendarDao = new CalendarDao();
            }
        }
        public async Task<ClientModel> GetClient(string uid)
        {
            var firebaseUser = await Util.GetUser(uid);

            var client = new ClientModel(clientDao.GetClient(uid))
            {
                Email = firebaseUser.Email,
                Appointments = clientDao.GetClientAppointments(uid),
                FavoriteProfessionals = clientDao.GetClientFavorites(uid)
            };

            return client;
                
        }

        public async Task<ClientModel> Register(HttpRequest req)
        {
            var uid = Util.GetUid(req).Result;

            string reqString = await Util.StreamToStringAsync(req);
            var registration = JsonConvert.DeserializeObject<GetClientResponse>(reqString);
            registration.FirebaseUid = uid;
            clientDao.AddClient(registration);
            return await GetClient(uid);
        }

        public void DeleteAccount(string uid)
        {
            clientDao.RemoveClient(uid);
        }

        public async Task<ClientModel> AddFavorite(string clientUid, HttpRequest request)
        {
            var requestString = await Util.StreamToStringAsync(request);
            var professionalUid = JsonConvert.DeserializeObject<FavoriteRequest>(requestString).Uid;
            clientDao.AddClientFavorite(clientUid, professionalUid);
            return await GetClient(clientUid);
        }
        public async Task<ClientModel> RemoveFavorite(string clientUid, HttpRequest request)
        {
            var requestString = await Util.StreamToStringAsync(request);
            var professionalUid = JsonConvert.DeserializeObject<FavoriteRequest>(requestString).Uid;
            clientDao.RemoveClientFavorite(clientUid, professionalUid);
            return await GetClient(clientUid);
        }

        public async Task<ClientModel> ScheduleAppointment(string clientUid, HttpRequest request)
        {
            var requestString = await Util.StreamToStringAsync(request);
            var appointmentRequest = JsonConvert.DeserializeObject<AppointmentRequest>(requestString);
            appointmentRequest.ClientFirebaseUid = clientUid;
            calendarDao.AddAppointment(appointmentRequest);
            return await GetClient(clientUid);
        }

    }
}
