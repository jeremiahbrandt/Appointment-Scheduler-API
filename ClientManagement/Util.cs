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
                    Credential = GoogleCredential.FromJson("{\"type\":\"service_account\",\"project_id\":\"selfproject-678ff\",\"private_key_id\":\"24b99280abc8654d1aaf0882132a7b5f2602bc91\",\"private_key\":\"-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCk4KdReJxZUOvH\nSvCOM2blVfIy1\\/p2\\/CuVed85h9XQ\\/4b\\/AdEGWIJ9rY33Ixo6fjgQX3ucSraFvbET\np5Yz9z4gNBGIY4LHoHpRiTARaVsgCX+TuZr5WSVzGdlz1KDPVG17oWNoePZtNZ\\/w\nvTWFrjHkobU6Dcr1Ue3QbHAgeOdgkSlPLbjLXugolhzXRPvKkWRsz1O84vf7eI+h\nEi2qPhtiN8mMtI3aLs6sBS+KhVLYJvEC7RSFSkFWnuohug+NpZL+Elixg3sS\\/WTC\n5AYmFhUKsMAM6hzYUuDmZreNu4pAJzug8JZqQwW1IpHJu1Q+y13FuPV7XJrB+u2M\nwcIGD4QrAgMBAAECggEADlgDBmn1RCnvkTN6UQy0v2\\/mNbknb5GJoyPqoSEpn1iT\noHzCeAhcNd3S83So0\\/zmGLqN0O+JCIKTtK+IODYiv\\/93pQNvPbm+2ngSZ\\/lf9Z4N\n7Mahbl7sjKJrkhGl+dORAMfuE4kuexrGstVrIhmg+pB86TOI\\/CWoCFFewdxy2Ko0\ncTlBIRqnbLcd1gQcgUC9eixV9pUTyHLY+0GTjqhuFvVQZhriRUDsitrlPjLvULD4\nwmt3nN\\/tyB8EZ5ISiysKK66zfvbBzQoM24VByFWK0NrAvCJRpNV3q7s0QT1PGZG1\nOOLGdw6R2vXlBhUhCWeg4KhZrqX9EYFlEKneJa9ZXQKBgQDdzNmgLD7vd2fC1Mvs\nZi8d2714iC9Ovb7t\\/iB6K4KGmOD4r7hEK6JYkVraRkS510HtnecF1R22vs6siU8e\nsZ5BySwv6BDurqvTMCqWhdToXpWc9inouAp6QsP2+0tolsiKhuxMH8wSVNj5nNhn\nPYLm36JFDsOWItH46DgsIi+B5wKBgQC+TONbkxQvDMxxnxDM4NCEtnrwj0ljQzg1\nfTPkj4xssgSFDWufxbVls\\/VVu9vz4FnvsC1GxqUR1Lrd6JarNUO3MCU2ydcXUrOu\nSKfpR5tCs1q2TNS7rHrBsDxm+cYIhdb9UOKfHYpIxoO9wg+1aq3zA2X9lfGB07H3\nW0kMscQrHQKBgQCo4equ8CG3mnaSPg9L3\\/5uQLvDBAbpcMbpVf+KpoiLTeq20K2A\nkqzZvUutOaXoz0Nu1zVqFny6ggzCCQcKevniY3hWvd\\/urWc9tcYnuJ2FlUdcLX95\nqHCp6R5nd65SY8Us3VEdIXT0XFCdt1R7P7Xlb1CSPoykS70PRlpHGHyN7wKBgDSP\nXfhr\\/hYkrc7wBR7hNRaCpCAPI1DkPwEfDJcjQsC+xlrNYx1k6P4nHyrH0S9hltWJ\nzmeO9Aahv98Mn5i4BHTzOkQQqXTKpdAMRzw6R9q7WOGjBNq0\\/87BU12JvTWbac7b\naUxTR19kXPyrPdV4moTVOnU41dRq2Oud7eYwryLNAoGBAMddmmCvzwN\\/wjU\\/T9Wk\n4rFE+AWdq64rnxCVwILvIsiAPzJpmxT6P+ktZgFyZGuaUonWZk48wgql7xSGfr9G\nIetbzyedeZbsFFzql4lbHL94\\/aRdmoFuMdlj63HigkbiqRWB2BaMoGgTD4NzpvWS\nhXXADKEMNZPegQvh9O2cbh0p\n-----END PRIVATE KEY-----\n\",\"client_email\":\"firebase-adminsdk-y0lw9@selfproject-678ff.iam.gserviceaccount.com\",\"client_id\":\"107628414496951926644\",\"auth_uri\":\"https:\\/\\/accounts.google.com\\/o\\/oauth2\\/auth\",\"token_uri\":\"https:\\/\\/oauth2.googleapis.com\\/token\",\"auth_provider_x509_cert_url\":\"https:\\/\\/www.googleapis.com\\/oauth2\\/v1\\/certs\",\"client_x509_cert_url\":\"https:\\/\\/www.googleapis.com\\/robot\\/v1\\/metadata\\/x509\\/firebase-adminsdk-y0lw9%40selfproject-678ff.iam.gserviceaccount.com\"}")
                });
            }

            Console.WriteLine($"\n\n{req.Headers["Authorization"]}\n\n");
             //return "x45mZ9SUWoTUgRagvruOSrIemgI2";
            var token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(req.Headers["Authorization"]);
            return token.Uid;
        }


        public static async Task<string> StreamToStringAsync(HttpRequest req)
        {
            using var sr = new StreamReader(req.Body);
            return await sr.ReadToEndAsync();
        }

        public static string GetConnectionString()
        {
            //return "data source=JEREMIAH-PC\\MSSQLSERVER01; initial catalog=SE39104/3/2021; persist security info=True; Integrated Security=SSPI;";
             return Environment.GetEnvironmentVariable("Sql_Connection");
        }

        public static async Task<UserRecord> GetUser(string uid)
        {
            return await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
        }
    }
}
