using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Model.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Model
{
    /// <summary>
    /// API для работы с гугл диском
    /// </summary>
    public class GoogleDriveApi
    {
        protected static string[] scopes = { DriveService.Scope.Drive };
        protected readonly UserCredential credential;
        static string ApplicationName = "GoogleDriveAPIStart";
        protected readonly DriveService service;

        /// <summary>
        /// Конструктор в которм происходит авторизация
        /// </summary>
        public GoogleDriveApi()
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

        public string GetFileId(string parentId, string fileName)
        {
            string pageToken = string.Empty;
            string fileId = string.Empty;
            do
            {
                var listRequest = service.Files.List();
                listRequest.PageSize = 100;
                listRequest.Fields = "nextPageToken, files(id, name, webContentLink)";
                listRequest.Q = $"'{parentId}' in parents and name = '{fileName}'";
                listRequest.PageToken = pageToken;

                var result = listRequest.Execute();
                pageToken = result.NextPageToken;

                foreach (var file in result.Files)
                {

                }
            } while (pageToken != null);
            return fileId;
        }

        /// <summary>
        /// Загрузить файл
        /// </summary>
        /// <param name="formFile">Загружаемый файл</param>
        /// <param name="parentId">Идентификатор папки</param>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        public Image UploadFile(IFormFile formFile, string parentId, string fileName)
        {
            var body = GetBody(parentId, fileName);

            FilesResource.CreateMediaUpload request;
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                using (var stream = new MemoryStream(memoryStream.ToArray()))
                {
                    request = service.Files.Create(body, stream, body.MimeType);
                    request.Fields = "id, name, webContentLink";
                    request.Upload();
                }
            }

            var file = request.ResponseBody;
            if (file == null) throw new KeyNotFoundException("Не удалось загрузить файл ВОЗМОЖНО ИСТЕК ТОКЕН НО ГУГОЛ ОБ ЭТОМ НЕ СКАЖЕТ ОН СТИСНЯЕТСЯ");
            return new Image()
            {
                GoogleFileId = file.Id,
                Name = file.Name,
                Link = file.WebContentLink
            };
        }

        /// <summary>
        /// Удалить файлы
        /// </summary>
        /// <param name="filesIds">Коллекция идентификаторов</param>
        public void DeleteFile(List<string> filesIds)
        {
            foreach (var id in filesIds)
                service.Files.Delete(id).Execute();
        }

        /// <summary>
        /// Обновить файл
        /// </summary>
        /// <param name="image">Сущность картинка</param>
        /// <param name="formFile">Обновляемый файл</param>
        /// <param name="parentId">Идентификатор папки</param>
        public void UpdateFile(Image image, IFormFile formFile, string parentId)
        {
            var body = GetBody(parentId, image.Name);

            FilesResource.UpdateMediaUpload request;
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                using (var stream = new MemoryStream(memoryStream.ToArray()))
                {
                    request = service.Files.Update(body, image.GoogleFileId, stream, body.MimeType);
                    request.Fields = "id, name, webContentLink";
                    request.Upload();
                }
            }
            var file = request.ResponseBody;
            if (file == null) throw new KeyNotFoundException("Не удалось загрузить файл ВОЗМОЖНО ИСТЕК ТОКЕН НО ГУГОЛ ОБ ЭТОМ НЕ СКАЖЕТ ОН СТИСНЯЕТСЯ");
        }

        /// <summary>
        /// Получить файл для гугла
        /// </summary>
        /// <param name="parentId">Идентификатор папки на гугл диске</param>
        /// <param name="fileName">Наименование файла</param>
        /// <returns></returns>
        private static Google.Apis.Drive.v3.Data.File GetBody(string parentId, string fileName)
        {
            var body = new Google.Apis.Drive.v3.Data.File();
            if (fileName.EndsWith(".jpg"))
                body.Name = fileName;
            else
                body.Name = $"{fileName}.jpg";
            body.MimeType = "image/jpeg";
            body.Parents = new List<string>() { parentId };
            return body;
        }
    }
}
