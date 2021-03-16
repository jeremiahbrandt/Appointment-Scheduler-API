using AppointmentManagerApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    interface IClientDao
    {
        Client GetClient(string uid);
        Client CreateClient();
    }
}
