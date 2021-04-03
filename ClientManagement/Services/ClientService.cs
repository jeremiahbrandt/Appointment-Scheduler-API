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
        private static ClientDao clientDao;
        public ClientService()
        {
            if(clientDao == null)
            {
                clientDao = new ClientDao();
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
            clientDao.AddClient(registration);
            return await GetClient(uid);
        }
    }
}
