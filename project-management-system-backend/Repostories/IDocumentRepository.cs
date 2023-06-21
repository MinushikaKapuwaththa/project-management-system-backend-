using project_management_system_backend.Models;
using Task = System.Threading.Tasks.Task;
using project_management_system_backend.Dtos.DocumentDtos;


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
