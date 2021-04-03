using AppointmentManagerApi.Data;
using AppointmentManagerApi.Model;
using ClientManagement;
using ClientManagement.Model;
using System;

namespace AppointmentManagerApi.Services
{
    class ClientService
    {
        public Client GetClient(string uid)
        {
            ClientDao clientDao = new ClientDao();
            AccountDao accountDao = new AccountDao();

            var email = Util.GetUser(uid).Result.DisplayName;
            var account = clientDao.GetClient(uid);
            var appointments = clientDao.GetClientAppointments(uid);
            var professionalAccount = accountDao.GetAccount();
            var favorites = clientDao.GetClientFavorites(uid);

            Client client = new Client() 
            {
                Account = new Account()
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    EmailAddress = email,
                    Uid = uid
                },
                Appointments = new Appointment[appointments.Count],
                FavoriteProfessionals = new ProfessionalModel[favorites.Count],
            };

            for (int i = 0; i < appointments.Count; i++)
            {
                var appointment = appointments[i];

                client.Appointments[i] = new Appointment()
                {
                    Name = appointment.AppointmentName,
                    Description = appointment.AppointmentDescription,
                    Professional = new ProfessionalModel()
                    {
                        Account = new Account()
                        {
                            FirstName = appointment.ProfessionalFirstName,
                            LastName = appointment.ProfessionalLastName,
                        },
                        Occupation = appointment.Occupation
                    },
                    Location = new Location()
                    {
                        StreetNumber = appointment.StreetNumber,
                        StreetName = appointment.StreetName,
                        City = appointment.City,
                        State = appointment.State,
                        ZipCode = appointment.ZipCode
                    },
                    TimeSlot = new TimeSlot()
                    {
                        StartTime = Convert.ToDateTime(appointment.StartTime.ToString()),
                        EndTime = Convert.ToDateTime(appointment.EndTime.ToString())
                    }
                };
            };
              

            for(int i=0; i<favorites.Count; i++)
            {
                var professional = favorites[i];

                client.FavoriteProfessionals[i] = new ProfessionalModel()
                {
                    Account = new Account()
                    {
                        FirstName = professional.FirstName,
                        LastName = professional.LastName
                    },
                    Occupation = professional.Occupation,
                    Location = new Location()
                    {
                        StreetNumber = professional.StreetNumber,
                        StreetName = professional.StreetName,
                        City = professional.City,
                        State = professional.State,
                        ZipCode = professional.ZipCode
                    }
                };
            }

            return client;
        }

        public Client Register()
        {
            throw new NotImplementedException();
        }
    }
}
