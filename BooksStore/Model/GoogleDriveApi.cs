using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace Model
{
    public class GoogleDriveApi
    {
        protected static string[] scopes = { DriveService.Scope.Drive };
        protected readonly UserCredential credential;
        static string ApplicationName = "GoogleDriveAPIStart";
        protected readonly DriveService service;

        public GoogleDriveApi ()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public string GetFileId(string folderId)
        {
            string pageToken = string.Empty;
            string fileId = string.Empty;
            do
            {
                var listRequest = service.Files.List();
                listRequest.PageSize = 100;
                listRequest.Fields = "nextPageToken, files(id, name, parents, createdTime, modifiedTime, mimeType)";
                listRequest.Q = $"'{folderId}' in parents";
                listRequest.PageToken = pageToken;

                var result = listRequest.Execute();
                pageToken = result.NextPageToken;

                foreach (var file in result.Files)
                {

                }
            } while (pageToken != null);
            return fileId;
        }
    }
}
