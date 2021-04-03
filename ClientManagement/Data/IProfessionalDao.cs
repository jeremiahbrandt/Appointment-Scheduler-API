using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    public interface IProfessionalDao
    {
        public GetProfessionalResponse AddProfessional();
        public GetProfessionalResponse GetProfessional(string uid);
        public IList<GetProfessionalTimeSlotsResponse> GetTimeSlots(string uid);
        public IList<GetProfessionalAppointmentsResponse> GetAppointments(string uid);
        public bool RemoveProfessional(string uid);
        public GetProfessionalResponse UpdateProfessional();
    }
}
