using AppointmentManagerApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Services
{
    interface ICalendarService
    {
        bool CancelAppointment(int appointmentId);
        bool RegisterForAppointment(int appointmentId, string clientUid);
        Appointment CreateAppointment();
    }
}
