using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using ClientManagement;
using System;

namespace AppointmentManagerApi.Services
{
    class ClientService
    {
        public Client GetClient(string uid)
        {
            ClientDao clientDao = new ClientDao();

            var email = Util.GetUser(uid).Result.DisplayName;
            var account = clientDao.GetClient(uid);
            var appointments = clientDao.GetClientAppointments(uid);
            var favorites = clientDao.GetClientFavorites(uid);

            Client client = new Client() 
            {
                Account = new ClientManagement.Model.Account()
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    EmailAddress = email,
                    Uid = uid
                },
                Appointments = new Appointment[appointments.Count],
                FavoriteProfessionals = new ProfessionalModel[favorites.Count],
            };

            return client;
        }

        public Client Register()
        {
            throw new NotImplementedException();
        }
    }
}
