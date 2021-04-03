using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using ClientManagement;
using ClientManagement.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
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
            var firebaseUser = await Util.GetUser(uid);
            ProfessionalDao dao = new ProfessionalDao();

            ProfessionalModel professional = new ProfessionalModel(dao.GetProfessional(uid))
            {
                Email = firebaseUser.Email,
                Appointments = dao.GetAppointments(uid),
                OpenTimeSlots = dao.GetTimeSlots(uid)
            };

            return professional;
        }
    }
}
