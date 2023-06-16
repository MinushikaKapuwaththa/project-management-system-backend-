using project_management_system_backend.Dtos.DocumentDtos;

namespace project_management_system_backend.Repostories 
{
    public interface IDocumentUploaderService
    {
        Task<DocumentUploadResult?> UploadDocument(DocumentUploadDto document);
        Task<byte[]?> DownloadDocument(string documentPath, string fileName);
        void RemoveDocumentFromRepository(string filePath, string actualFileName);
    }
}
