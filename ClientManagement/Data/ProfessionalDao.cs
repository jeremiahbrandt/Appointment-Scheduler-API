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
    public class ProfessionalDao : IProfessionalDao
    {
        public void AddProfessional(ProfessionalRegistrationRequest professionalRegistrationRequest)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "AddProfessional";
                var values = professionalRegistrationRequest;
                connection.Query<GetProfessionalResponse>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
        public GetProfessionalResponse GetProfessional(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "GetProfessional";
                var values = new { FirebaseUid = uid };
                var result = connection.Query<GetProfessionalResponse>(procedure, values, commandType: CommandType.StoredProcedure).First();

                return result;
            }
        }
        public GetProfessionalResponse UpdateProfessional()
        {
            throw new NotImplementedException();
        }

        public IList<GetProfessionalTimeSlotsResponse> GetTimeSlots(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "GetProfessionalTimeSlots";
                var values = new { FirebaseUid = uid };
                var result = connection.Query<GetProfessionalTimeSlotsResponse>(procedure, values, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public IList<GetProfessionalAppointmentsResponse> GetAppointments(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "GetProfessionalAppointments";
                var values = new { FirebaseUid = uid };
                var result = connection.Query<GetProfessionalAppointmentsResponse>(procedure, values, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public bool RemoveProfessional(string uid)
        {
            throw new NotImplementedException();
        }
    }
}
