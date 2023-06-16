using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public interface IClientPersonRepository
    {
        Task<List<Client>> GetAllClientsDetails();
        Task<Client> GetClientId(int Id);
        Task<Client> CreateClient(Client client);
        Task DeleteClient(Client clientToDelete);
        Task<Client> UpdateClient(Client client);
    }
}
