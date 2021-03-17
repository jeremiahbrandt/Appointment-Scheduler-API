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
        public static FirebaseAuth GetFirebase()
        {
            var firebase = FirebaseAuth.DefaultInstance;

            if (firebase == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("../../../service-account-file.json")
                });

                firebase = FirebaseAuth.DefaultInstance;
            }

            return firebase;
        }

        public static async Task<string> GetUid(string jwt)
        {
            Console.WriteLine(jwt);
            var token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(jwt);
            return token.Uid;
        }


        public static async Task<string> StreamToStringAsync(HttpRequest req)
        {
            using var sr = new StreamReader(req.Body);
            return await sr.ReadToEndAsync();
        }

        public static string GetConnectionString()
        {
            string connection = Environment.GetEnvironmentVariable("Sql_Connection");
            return connection;
        }

        public static async Task<UserRecord> GetUser(string uid)
        {
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
            return userRecord;
        }
    }
}
