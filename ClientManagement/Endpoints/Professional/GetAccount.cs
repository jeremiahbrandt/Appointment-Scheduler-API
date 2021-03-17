using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FirebaseAdmin.Auth;
using static ClientManagement.Util;
using AppointmentManagerApi.Services;
using AppointmentManagerApi.Model;

namespace ClientManagement.Endpoints.Professional
{
    public static class GetAccount
    {
        [FunctionName("Professional")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "professional")] HttpRequest req, ILogger log)
        {
            FirebaseAuth firebase = Util.GetFirebase();
            string uid = GetUid(req.Headers["Authorization"]).Result;

            ProfessionalService professionalService = new ProfessionalService();
            ProfessionalModel professional = await professionalService.GetProfessional(uid);

            return new OkObjectResult(professional);
        }
    }
}
