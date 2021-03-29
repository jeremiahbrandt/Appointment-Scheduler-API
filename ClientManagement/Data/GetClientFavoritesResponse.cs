using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    class GetClientFavoritesResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Uid { get; set; }
        public string Occupation { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
