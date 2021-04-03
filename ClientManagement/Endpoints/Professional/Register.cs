using System.Threading.Tasks;
using AppointmentManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AppointmentManagerApi.Endpoints.Professional
{
    public static class Register
    {
        [FunctionName("RegisterProfessional")]
        public static async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "professional/register")] HttpRequest req, ILogger log)
        {
            ProfessionalService professionalService = new ProfessionalService();
            var professional = await professionalService.Register(req);

            return new OkObjectResult(professional);
        }
    }
}

