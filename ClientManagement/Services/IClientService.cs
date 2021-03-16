using AppointmentManagerApi.Model;

namespace AppointmentManagerApi.Services
{
    interface IClientService
    {
        Client Register();
        Client GetClient(string uid);
    }
}
