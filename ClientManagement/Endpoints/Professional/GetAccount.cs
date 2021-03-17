using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AppointmentManagerApi.Services;
using AppointmentManagerApi.Model;

namespace ClientManagement.Endpoints.Professional
{
    public static class GetAccount
    {
        [FunctionName("Professional")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "professional")] HttpRequest req, ILogger log)
        {
            ProfessionalService professionalService = new ProfessionalService();
            var uid = Util.GetUid(req).Result;
            ProfessionalModel professional = await professionalService.GetProfessional(uid);

            return new OkObjectResult(professional);
        }
    }
}
