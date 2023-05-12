using project_management_system_backend.Enums;
using project_management_system_backend.Models;


namespace project_management_system_backend.Repostories
{
    public class DocumentUploaderService : IDocumentUploaderService
    {
        private readonly string _documentBasePath;
        public DocumentUploaderService(IConfiguration configuration)
        {
            _documentBasePath = configuration["DocumentRepository"] ?? string.Empty;
        }

        public async Task<DocumentUploadResult?> UploadDocument(DocumentUploadDto document)
        {
            try
            {
                var pathToSave = string.Empty;
                if (document != null && document.File != null)
                {
                    var file = document.File;
                    var folderName = Enum.GetName((DocumentTypeEnum)document.Type) ?? "Others";

                    pathToSave = Directory.GetParent(Directory.GetCurrentDirectory()) + _documentBasePath;

                    pathToSave = Path.Combine(pathToSave, folderName);

                    if (!Directory.Exists(pathToSave))
                    {
                        Directory.CreateDirectory(pathToSave);
                    }
                    var filePath = Path.Combine(pathToSave, file.FileName);

                    int count = 1;
                    while (File.Exists(filePath))
                    {
                        count++;
                        filePath = Path.Combine(pathToSave, $"{Path.GetFileNameWithoutExtension(file.FileName)}({count}){Path.GetExtension(file.FileName)}");
                    }

                    using var fileStream = File.Open(filePath, FileMode.CreateNew);
                    await file.CopyToAsync(fileStream);

                    return new DocumentUploadResult
                    {
                        Name = document.Name,
                        ClientName = document.ClientName,
                        Company = document.Company,
                        Type = document.Type,
                        Status = (int)StatusEnum.Active,
                        DocumentPath = Path.GetFullPath(pathToSave),
                        ActualFileName = Path.GetFileName(filePath),
                        ProjectId = document.ProjectId
                    };
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<byte[]?> DownloadDocument(string documentPath, string fileName)
        {
            var docPath = documentPath + "\\" + fileName;

            // check whether the file exists
            if (!File.Exists(docPath))
            {
                return null;
            }
            var bytes = await File.ReadAllBytesAsync(docPath);
            return bytes;
        }

        public void RemoveDocumentFromRepository(string filePath, string actualFileName)
        {
            var docPath = filePath + "\\" + actualFileName;
            if (File.Exists(docPath))
            {
                File.Delete(docPath);
            }
        }
    }
}

