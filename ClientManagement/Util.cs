using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace ClientManagement
{
    class Util
    {
        protected static FirebaseAuth GetFirebase()
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
    }
}
