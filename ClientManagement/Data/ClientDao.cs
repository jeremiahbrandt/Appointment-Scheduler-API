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
    class ClientDao
    {
        public Client CreateClient()
        {
            throw new NotImplementedException();
        }

        public GetClientResponse GetClient(string uid) {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "Get_Client";
                var values = new { Uid = uid };
                var result = connection.Query<GetClientResponse>(procedure, values, commandType: CommandType.StoredProcedure).First();

                return result;
            }
        }

        public IList<GetClientAppointmentsResponse> GetClientAppointments(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "Get_Client_Appointments";
                var values = new { Uid = uid };
                var result = connection.Query<GetClientAppointmentsResponse>(procedure, values, commandType: CommandType.StoredProcedure).AsList();

                return result;
            }
        }

        public IList<GetClientFavoritesResponse> GetClientFavorites(string uid)
        {
            using (var connection = new SqlConnection(Util.GetConnectionString()))
            {
                var procedure = "Get_Client_Favorites";
                var values = new { Uid = uid };
                var result = connection.Query<GetClientFavoritesResponse>(procedure, values, commandType: CommandType.StoredProcedure).AsList();

                return result;
            }
        }

        public GetProfessionalResponse GetProfessional(string uid)
        {
            throw new NotImplementedException();
        }
    }
}
