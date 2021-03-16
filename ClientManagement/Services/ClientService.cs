using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using System;

namespace AppointmentManagerApi.Services
{
    class ClientService : IClientService
    {
        public Client GetClient(string uid)
        {
            Client client = new ClientDao().GetClient(uid);
            return client;
        }

        public Client Register()
        {
            throw new NotImplementedException();
        }
    }
}
