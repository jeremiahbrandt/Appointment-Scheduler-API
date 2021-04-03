using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using ClientManagement;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AppointmentManagerApi.Services
{
    class ProfessionalService
    {
        private static ProfessionalDao professionalDao;
        public ProfessionalService()
        {
            if(professionalDao == null)
            {
                professionalDao = new ProfessionalDao();
            }
        }

        public async Task<ProfessionalModel> Register(HttpRequest req)
        {
            var uid = Util.GetUid(req).Result;

            string reqString = await Util.StreamToStringAsync(req);
            var registration =  JsonConvert.DeserializeObject<ProfessionalRegistrationRequest>(reqString);
            professionalDao.AddProfessional(registration);
            return await GetProfessional(uid);
        }

        public async Task<ProfessionalModel> GetProfessional(string uid)
        {
            var firebaseUser = await Util.GetUser(uid);

            ProfessionalModel professional = new ProfessionalModel(professionalDao.GetProfessional(uid))
            {
                Email = firebaseUser.Email,
                Appointments = professionalDao.GetAppointments(uid),
                OpenTimeSlots = professionalDao.GetTimeSlots(uid)
            };

            return professional;
        }

        public bool DeleteProfessionalAccount(string uid)
        {
            try
            {
                professionalDao.RemoveProfessional(uid);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
