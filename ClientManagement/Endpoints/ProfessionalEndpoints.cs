using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FirebaseAdmin.Auth;

namespace ClientManagement.Service
{
    public static class ProfessionalEndpoints
    {
        [FunctionName("Professional")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            FirebaseAuth firebase = Util.GetFirebase();

            FirebaseToken firebaseToken = await firebase.VerifyIdTokenAsync(req.Headers["Authorization"]);
            UserRecord userRecord = await firebase.GetUserAsync(firebaseToken.Uid);

            return new OkObjectResult(File.ReadAllText("C:\\Users\\jerem\\source\\repos\\ClientManagement\\ClientManagement\\DummyData\\ExampleProfessional.json"));
        }
    }
}
