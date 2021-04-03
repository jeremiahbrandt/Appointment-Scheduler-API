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

namespace AppointmentManagerApi.Endpoints.Professional
{
    public static class DeleteAccount
    {
        [FunctionName("DeleteProfessional")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "professional")] HttpRequest req, ILogger log)
        {
            ProfessionalService professionalService = new ProfessionalService();
            var uid = Util.GetUid(req).Result;
            professionalService.DeleteProfessionalAccount(uid);
            return new NoContentResult();
        }
    }
}

