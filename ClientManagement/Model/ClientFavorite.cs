using ClientManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Model
{
    class ClientFavorite
    {
        public Account Account { get; set; }
        public Location Location { get; set; }
        public string Occupation { get; set; }
    }
}
