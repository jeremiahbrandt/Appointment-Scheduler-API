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
        private static IProfessionalDao professionalDao;
        private static ICalendarDao calendarDao;
        public ProfessionalService()
        {
            if(professionalDao == null)
            {
                professionalDao = new ProfessionalDao();
            }
            if (calendarDao == null)
            {
                calendarDao = new CalendarDao();
            }
        }

        public async Task<ProfessionalModel> Register(HttpRequest req)
        {
            var uid = Util.GetUid(req).Result;

            string reqString = await Util.StreamToStringAsync(req);
            var registration =  JsonConvert.DeserializeObject<ProfessionalRegistrationRequest>(reqString);
            registration.FirebaseUid = await Util.GetUid(req);
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

        public void DeleteProfessionalAccount(string uid)
        {
            professionalDao.RemoveProfessional(uid);

        }

        public async Task<ProfessionalModel> AddTimeSlot(HttpRequest request) 
        {
            var uid = Util.GetUid(request).Result;

            var requestString = await Util.StreamToStringAsync(request);
            var timeslot = JsonConvert.DeserializeObject<TimeSlotModel>(requestString);


            calendarDao.AddTimeSlot(uid, timeslot);
            var professional = GetProfessional(uid).Result;
            return professional;
        }

        public async Task<ProfessionalModel> UpdateProfessional(HttpRequest request)
        {
            var uid = Util.GetUid(request).Result;

            string reqString = await Util.StreamToStringAsync(request);
            var registration = JsonConvert.DeserializeObject<ProfessionalRegistrationRequest>(reqString);
            registration.FirebaseUid = await Util.GetUid(request);
            professionalDao.UpdateProfessional(registration);
            return await GetProfessional(uid);
        }
    }
}
