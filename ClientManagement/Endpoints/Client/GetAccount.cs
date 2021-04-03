using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AppointmentManagerApi.Services;
using AppointmentManagerApi.Model;
using System.Threading.Tasks;

namespace ClientManagement.Endpoints.Client
{
    public static class GetAccount
    {
        [FunctionName("Client")]
        public static async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "client")] HttpRequest req, ILogger log)
        {
            ClientService clientService = new ClientService();
            var uid = Util.GetUid(req).Result;
            ClientModel client = await clientService.GetClient(uid);

            return new OkObjectResult(client);
        }
    }
}
