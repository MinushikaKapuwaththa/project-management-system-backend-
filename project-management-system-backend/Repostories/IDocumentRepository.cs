using project_management_system_backend.Models;


namespace project_management_system_backend.Repostories
{
    public interface IDocumentRepository
    {
        Task SaveDocumentMetaData(DocumentUploadResult documentResult);
        Task<List<DocumentDetailsDto>> GetDocumentListAsync();
        Task<Document?> GetDocumentByIdAsync(int documentId);
        Task DeleteDocumentAsync(Document documentToDelete);
    }
}
