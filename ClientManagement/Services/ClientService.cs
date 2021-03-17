using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using System;

namespace AppointmentManagerApi.Services
{
    class ClientService
    {
        public Client GetClient(string uid)
        {
            ClientDao clientDao = new ClientDao();

            var IEn = clientDao.GetClientAppointments(uid);
            var appointments = clientDao.GetClientAppointments(uid);
            var favorites = clientDao.GetClientFavorites(uid);

            Client client = new Client() 
            {
                Account = new ClientManagement.Model.Account()
                {
                    
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
