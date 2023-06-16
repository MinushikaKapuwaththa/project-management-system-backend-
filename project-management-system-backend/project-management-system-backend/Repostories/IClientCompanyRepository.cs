using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public interface IClientCompanyRepository
    {
        Task<List<ClientCompany>> GetAllClientDetails();
        Task<ClientCompany> GetClientId(int Id);
        Task<ClientCompany> CreateClient(ClientCompany clientCompany);
        Task<ClientCompany> UpdateClient(ClientCompany clientCompany);
    }
}
