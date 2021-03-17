using AppointmentManagerApi.Model;
using ClientManagement.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppointmentManagerApi.Data
{
    class ClientDao
    {
        public Client CreateClient()
        {
            throw new NotImplementedException();
        }

        public Client GetClient(string uid)
        {
            string json = File.ReadAllText("C:\\Users\\jerem\\source\\repos\\ClientManagement\\ClientManagement\\DummyData\\ExampleClient.json");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Client>(json);
        }
    }
}
