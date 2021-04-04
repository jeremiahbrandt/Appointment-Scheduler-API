using AppointmentManagerApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagerApi.Data
{
    interface ICalendarDao
    {
        public void AddTimeSlot(string uid, TimeSlotModel timeSlot);
        public void RemoveTimeSlot(int timeSlotId);
        public void AddAppointment(AppointmentRequest appointmentRequest);
        public void RemoveAppointment(int timeSlotId);
    }
}
