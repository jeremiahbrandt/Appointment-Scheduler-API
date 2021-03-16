using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
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
                    Credential = GoogleCredential.FromFile("C:\\Users\\jerem\\Downloads\\service-account-file.json")
                });

                firebase = FirebaseAuth.DefaultInstance;
            }

            return firebase;
        }

        public static async Task<string> GetUid(string jwt)
        {
            var token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(jwt);
            return token.Uid;
        }
    }
}
