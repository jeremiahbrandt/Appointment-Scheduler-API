using AppointmentManagerApi.Model;
using ClientManagement;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AppointmentManagerApi.Data
{
    class ProfessionalDao
    {
        public ProfessionalModel CreateAccount(ProfessionalModel professional)
        {
            Console.WriteLine(Util.GetConnectionString());
            return new ProfessionalModel();
        }

        public GetProfessionalResponse GetProfessional(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "Get_Professional";
                var values = new { Uid = uid };
                var result = connection.Query<GetProfessionalResponse>(procedure, values, commandType: CommandType.StoredProcedure).First();

                return result;
            }
        }

        public IEnumerable<GetProfessionalAppointmentsResponse> GetProfessionalAppointments(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "Get_Professional_Appointments";
                var values = new { Uid = uid };
                var result = connection.Query<GetProfessionalAppointmentsResponse>(procedure, values, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<GetProfessionalTimeSlotsResponse> GetProfessionalTimeSlots(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "Get_Professional_TimeSlots";
                var values = new { Uid = uid };
                var result = connection.Query<GetProfessionalTimeSlotsResponse>(procedure, values, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
