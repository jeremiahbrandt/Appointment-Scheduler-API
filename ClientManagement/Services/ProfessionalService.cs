using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using ClientManagement;
using ClientManagement.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AppointmentManagerApi.Services
{
    class ProfessionalService
    {
        public async Task<ProfessionalModel> Register(HttpRequest req)
        {
            string reqString = await Util.StreamToStringAsync(req);
            ProfessionalModel inputProfessionalModel =  JsonConvert.DeserializeObject<ProfessionalModel>(reqString);
          /*  ProfessionalModel resultProfessionalModel = await new ProfessionalDao().CreateAccount(inputProfessionalModel);*/

            return new ProfessionalModel();
        }

        public async Task<ProfessionalModel> GetProfessional(string uid)
        {
            ProfessionalDao dao = new ProfessionalDao();
            var getProfessional = dao.GetProfessional(uid);
          /*  var appointments = dao.GetProfessionalAppointments(uid);
            var timeSlots = dao.GetProfessionalTimeSlots(uid);*/
            var user = await Util.GetUser(uid);

            ProfessionalModel professional = new ProfessionalModel()
            {
                Occupation = getProfessional.Occupation,
                Account = new Account()
                {
                    FirstName = user.DisplayName,
                    EmailAddress = user.DisplayName,
                    Uid = user.Uid
                },
                Location = new Location()
                {
                    StreetNumber = getProfessional.StreetNumber,
                    StreetName = getProfessional.StreetName,
                    City = getProfessional.City,
                    State = getProfessional.State,
                    ZipCode = getProfessional.ZipCode
                },
            };

            return professional;
        }
    }
}
