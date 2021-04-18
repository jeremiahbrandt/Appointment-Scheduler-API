using AppointmentManagerApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    public interface IProfessionalDao
    {
        public void AddProfessional(ProfessionalRegistrationRequest professionalRegistrationRequest);
        public GetProfessionalResponse GetProfessional(string uid);
        public GetProfessionalResponse GetProfessionalByCode(string code);
        public IList<GetProfessionalTimeSlotsResponse> GetTimeSlots(string uid);
        public IList<GetProfessionalAppointmentsResponse> GetAppointments(string uid);
        public void RemoveProfessional(string uid);
        public void UpdateProfessional(ProfessionalRegistrationRequest request);
    }
}
