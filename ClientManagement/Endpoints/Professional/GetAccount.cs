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
            var professionalService = new ProfessionalService();
            string code = req.Query["code"];

            ProfessionalModel professional;
            if(code != null)
            {
                professional = professionalService.GetProfessionalByCode(code);
            } 
            else
            {
                var uid = Util.GetUid(req).Result;
                professional = await professionalService.GetProfessional(uid);
            }

            return new OkObjectResult(professional);
        }
    }
}
