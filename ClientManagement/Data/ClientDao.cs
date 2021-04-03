using AppointmentManagerApi.Model;
using ClientManagement;
using ClientManagement.Model;
using Dapper;
using System;
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

        public GetClientResponse AddClientFavorite(string clientUid, string professionalUid)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public GetClientResponse RemoveClientFavorite(string clientUid, string professionalUid)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(GetClientResponse client)
        {
            throw new NotImplementedException();
        }
    }
}
