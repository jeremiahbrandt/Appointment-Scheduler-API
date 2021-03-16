using System.IO;
/*
 * 
using System.Threading.Tasks;
using ClientManagement;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AppointmentManagerApi.Endpoints.Client
{
    public static class Template
    {
        [FunctionName("RegisterClient")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "client/register")] HttpRequest req, ILogger log)
        {
            FirebaseAuth firebase = Util.GetFirebase();
            string uid = Util.GetUid(req.Headers["Authorization"]).Result;

            UserRecord userRecord = await firebase.GetUserAsync(uid);

            return new OkObjectResult(File.ReadAllText("C:\\Users\\jerem\\source\\repos\\ClientManagement\\ClientManagement\\DummyData\\ExampleClient.json"));
        }
    }
}

*/

