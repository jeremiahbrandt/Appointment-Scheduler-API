using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Model
{
    class ClientFavorite
    {
        public string ProfessionalUid { get; set; }
        public string Occupation { get; set; }
        public int StreetNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }
}
