using System.IO;
using System.Threading.Tasks;
using AppointmentManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AppointmentManagerApi.Endpoints.Professional
{
    public static class UpdateProfessional
    {
        [FunctionName("UpdateProfessional")]
        public static async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "professional")] HttpRequest req, ILogger log)
        {
            ProfessionalService professionalService = new ProfessionalService();
            var professional = await professionalService.UpdateProfessional(req);

            return new OkObjectResult(professional);
        }
    }
}

