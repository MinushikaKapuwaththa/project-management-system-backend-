using project_management_system_backend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace project_management_system_backend.Repostories
{
    public interface IClientCompanyRepository
    {
        Task<List<ClientCompany>> GetAllClientDetails();
        Task<ClientCompany> GetClientId(int Id);
        Task<ClientCompany> CreateClient(ClientCompany clientCompany);
        Task DeleteClient(ClientCompany clientToDelete);
        Task<ClientCompany> UpdateClient(ClientCompany clientCompany);
    }
}
