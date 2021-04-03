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
            var getProfessional = dao.GetProfessional(uid);
            var getAppointments = dao.GetAppointments(uid);
            var getTimeSlots = dao.GetTimeSlots(uid);

            ProfessionalModel professional = new ProfessionalModel()
            {
                Occupation = getProfessional.Occupation,
                Account = new Account()
                {
                    FirstName = getProfessional.FirstName,
                    LastName = getProfessional.LastName,
                    EmailAddress = firebaseUser.Email,
                    Uid = firebaseUser.Uid
                },
                Location = new Location()
                {
                    StreetNumber = getProfessional.StreetNumber,
                    StreetName = getProfessional.StreetName,
                    City = getProfessional.City,
                    State = getProfessional.State,
                    ZipCode = getProfessional.ZipCode
                },
                Appointments = new Appointment[getAppointments.Count],
                OpenTimeSlots = new TimeSlot[getTimeSlots.Count]
            };

            for(int i=0; i<getAppointments.Count; i++)
            {
                var app = getAppointments[i];

                professional.Appointments[i] = new Appointment()
                {
                    TimeSlot = new TimeSlot()
                    {
                        StartTime = Convert.ToDateTime(app.StartTime.ToString()),
                        EndTime = Convert.ToDateTime(app.EndTime.ToString()),
                    },
                    Location = new Location()
                    {
                        StreetNumber = getProfessional.StreetNumber,
                        StreetName = getProfessional.StreetName,
                        City = getProfessional.City,
                        State = getProfessional.State,
                        ZipCode = getProfessional.ZipCode
                    }

                };
            }

            return professional;
        }
    }
}
