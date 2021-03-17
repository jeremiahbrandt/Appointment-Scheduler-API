using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FirebaseAdmin.Auth;
using AppointmentManagerApi.Services;
using AppointmentManagerApi.Model;

namespace ClientManagement.Endpoints.Client
{
    public static class GetAccount
    {
        [FunctionName("Client")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "client")] HttpRequest req, ILogger log)
        {
            FirebaseAuth firebase = Util.GetFirebase();
            string uid = Util.GetUid(req.Headers["Authorization"]).Result;

            var client = new ClientService().GetClient(uid);
            return new OkObjectResult(client);
        }
    }
}
