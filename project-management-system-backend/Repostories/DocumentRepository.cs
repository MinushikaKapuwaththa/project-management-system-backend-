
using project_management_system_backend.Data;
using project_management_system_backend.Dtos.DocumentDtos;
using Microsoft.EntityFrameworkCore;
using project_management_system_backend.Models;
using Task = System.Threading.Tasks.Task;

namespace project_management_system_backend.Repostories
{
    
    
        public class DocumentRepository : IDocumentRepository
        {
            private readonly ApiDbContext _context;

            public DocumentRepository(ApiDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task SaveDocumentMetaData(DocumentUploadResult documentResult)
            {
                documentResult.ProjectId = documentResult.ProjectId == 0 ? null : documentResult.ProjectId;
                documentResult.ClientId = documentResult.ClientId;
            Document documentData = new()
                {
                    ClientId = documentResult.ClientId,
                    Name = documentResult.Name,
                    Type = (Enums.DocumentTypeEnum)documentResult.Type,
                    Company = documentResult.Company,
                    Status = (Enums.StatusEnum)documentResult.Status,
                    UploadTime = DateTime.Now,
                    FilePath = documentResult.DocumentPath,
                    ActualFileName = documentResult.ActualFileName,
                    ProjectId = documentResult.ProjectId
                };

                _context.Documents.Add(documentData);
                await _context.SaveChangesAsync();
            }

            public async Task<List<DocumentDetailsDto>> GetDocumentListAsync()
            {
                var documents = await _context.Documents.Where(d => d.Status == Enums.StatusEnum.Active)
                     .Select(d => new DocumentDetailsDto
                     {
                         DocumentId = d.DocumentId,
                         Name = d.Name,
                         ClientId = d.ClientId,
                         Company = d.Company,
                         Date = d.UploadTime,
                         Type = Enum.GetName(d.Type) ?? "Others",
                         ActualFileName = d.ActualFileName,
                         ProjectName = d.Project == null ? string.Empty : d.Project.Name,
                     }).ToListAsync();

                return documents;
            }

            public async Task<Document?> GetDocumentByIdAsync(int documentId)
            {
                return await _context.Documents.FirstOrDefaultAsync(d => d.DocumentId == documentId);
            }

            public async Task DeleteDocumentAsync(Document documentToDelete)
            {
                _context.Documents.Remove(documentToDelete);
                await _context.SaveChangesAsync();
            }


        }
    }

