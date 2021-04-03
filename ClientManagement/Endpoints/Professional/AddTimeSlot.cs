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
    public static class AddTimeSlot
    {
        [FunctionName("AddTimeSlot")]
        public static async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "professional/timeslots")] HttpRequest req, ILogger log)
        {
            var professionalService = new ProfessionalService();
            var professional = await professionalService.AddTimeSlot(req);

            return new OkObjectResult(professional);
        }
    }
}

