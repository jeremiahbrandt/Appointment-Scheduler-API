using ClientManagement;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AppointmentManagerApi.Data
{
    class ClientDao : IClientDao
    {
        public void AddClient(GetClientResponse client)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "AddClient";
                var values = client;
                connection.Query<GetClientResponse>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddClientFavorite(string clientUid, string professionalUid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "AddClientFavorite";
                var values = new 
                { 
                    ClientFirebaseUid = clientUid,
                    ProfessionalFirebaseUid = professionalUid
                };
                connection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public GetClientResponse GetClient(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "GetClient";
                var values = new { FirebaseUid = uid };
                var result = connection.Query<GetClientResponse>(procedure, values, commandType: CommandType.StoredProcedure).First();

                return result;
            }
        }

        public IList<GetClientAppointmentsResponse> GetClientAppointments(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "GetClientAppointments";
                var values = new { FirebaseUid = uid };
                var result = connection.Query<GetClientAppointmentsResponse>(procedure, values, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public IList<GetClientFavoritesResponse> GetClientFavorites(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "GetClientFavorites";
                var values = new { FirebaseUid = uid };
                var result = connection.Query<GetClientFavoritesResponse>(procedure, values, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public void RemoveClient(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "RemoveClient";
                var values = new { FirebaseUid = uid };
                connection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveClientFavorite(string clientUid, string professionalUid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "RemoveClientFavorite";
                var values = new
                {
                    ClientFirebaseUid = clientUid,
                    ProfessionalFirebaseUid = professionalUid
                };
                connection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateClient(GetClientResponse client)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "UpdateClient";
                var values = client;
                connection.Query<GetClientResponse>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
