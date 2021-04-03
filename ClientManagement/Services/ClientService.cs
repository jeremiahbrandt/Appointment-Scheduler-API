using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using ClientManagement;
using ClientManagement.Model;
using System;
using System.Threading.Tasks;

namespace AppointmentManagerApi.Services
{
    class ClientService
    {
        public async Task<ClientModel> GetClient(string uid)
        {
            var firebaseUser = await Util.GetUser(uid);
            var clientDao = new ClientDao();

            var client = new ClientModel(clientDao.GetClient(uid))
            {
                Email = firebaseUser.Email,
                Appointments = clientDao.GetClientAppointments(uid),
                FavoriteProfessionals = clientDao.GetClientFavorites(uid)
            };

            return client;
                
        }

        public ClientModel Register()
        {
            throw new NotImplementedException();
        }
    }
}
