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
    public static class DeleteAccount
    {
        [FunctionName("DeleteClientAccount")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "client")] HttpRequest req, ILogger log)
        {
            var clientService = new ClientService();
            var uid = Util.GetUid(req).Result;
            var success = clientService.DeleteAccount(uid);
            if (success)
            {
                return new NoContentResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}

