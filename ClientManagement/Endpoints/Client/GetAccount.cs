using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AppointmentManagerApi.Services;

namespace ClientManagement.Endpoints.Client
{
    public static class GetAccount
    {
        [FunctionName("Client")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "client")] HttpRequest req, ILogger log)
        {
            var uid = Util.GetUidAsync(req).Result;

            var client = new ClientService().GetClient(uid);
            return new OkObjectResult(client);
        }
    }
}
