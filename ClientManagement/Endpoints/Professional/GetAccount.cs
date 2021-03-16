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

namespace ClientManagement.Endpoints.Professional
{
    public static class GetAccount
    {
        [FunctionName("Professional")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            FirebaseAuth firebase = Util.GetFirebase();
            string uid = Util.GetUid(req.Headers["Authorization"]).Result;

            UserRecord userRecord = await firebase.GetUserAsync(uid);

            return new OkObjectResult(File.ReadAllText("C:\\Users\\jerem\\source\\repos\\ClientManagement\\ClientManagement\\DummyData\\ExampleProfessional.json"));
        }
    }
}
