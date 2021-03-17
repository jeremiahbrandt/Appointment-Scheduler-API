using System.IO;
using System.Threading.Tasks;
using ClientManagement;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AppointmentManagerApi.Endpoints.Client
{
    public static class Register
    {
        [FunctionName("RegisterClient")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "client/register")] HttpRequest req, ILogger log)
        {
            return new OkObjectResult("");
        }
    }
}

