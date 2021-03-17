using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ClientManagement
{
    class Util
    {
        public static async Task<string> GetUid(HttpRequest req)
        {
            if (FirebaseAuth.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(Environment.GetEnvironmentVariable("FirebaseServiceAccount"))
                });
            }

            Console.WriteLine($"\n\n{req.Headers["Authorization"]}\n\n");
            //var token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(req.Headers["Authorization"]);
            //return token.Uid;
             return "Z5hkKNzr1SRbhI2v9XRQNnvi8bh2";
        }


        public static async Task<string> StreamToStringAsync(HttpRequest req)
        {
            using var sr = new StreamReader(req.Body);
            return await sr.ReadToEndAsync();
        }

        public static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("Sql_Connection");
        }

        public static async Task<UserRecord> GetUser(string uid)
        {
            return await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
        }
    }
}
