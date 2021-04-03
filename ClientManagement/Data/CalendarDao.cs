using AppointmentManagerApi.Model;
using ClientManagement;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AppointmentManagerApi.Data
{
    public class CalendarDao : ICalendarDao
    {
        public void AddAppointment(string clientUid, int timeSlotId)
        {
            throw new NotImplementedException();
        }

        public void AddTimeSlot(string uid, TimeSlotModel timeSlot)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "AddTimeSlot";
                var values = new 
                {
                    ProfessionalFirebaseUid = uid,
                    StartTime = timeSlot.StartTime,
                    EndTime = timeSlot.EndTime
                };
                connection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveAppointment(int timeSlotId)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "RemoveTimeSlot";
                var values = new { timeSlotId = timeSlotId };
                connection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveTimeSlot(int timeSlotId)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "RemoveTimeSlot";
                var values = new { timeSlotId = timeSlotId };
                connection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
