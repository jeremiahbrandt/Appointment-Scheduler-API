using System.IO;
using System.Threading.Tasks;
using AppointmentManagerApi.Services;
using ClientManagement;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AppointmentManagerApi.Model;

namespace AppointmentManagerApi.Endpoints.Professional
{
    public static class Register
    {
        [FunctionName("RegisterProfessional")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "professional/register")] HttpRequest req, ILogger log)
        {
            return new OkObjectResult("");
        }
    }
}

