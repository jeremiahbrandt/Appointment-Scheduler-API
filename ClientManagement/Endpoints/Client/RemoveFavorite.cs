using System.IO;
using System.Threading.Tasks;
using AppointmentManagerApi.Services;
using ClientManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AppointmentManagerApi.Endpoints.Client
{
    public static class RemoveFavorite
    {
        [FunctionName("RemoveFavorite")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "client/favorites")] HttpRequest req, ILogger log)
        {
            var clientService = new ClientService();
            try
            {
                var uid = Util.GetUid(req).Result;
                return new OkObjectResult(clientService.RemoveFavorite(uid, req).Result);

            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}

