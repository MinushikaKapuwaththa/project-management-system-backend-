using project_management_system_backend.Models;
using Task = System.Threading.Tasks.Task;

namespace project_management_system_backend.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(int clientId);
        Task CreateClientAsync(Client clientToCreate);
        Task DeleteClientAsync(Client clientToDelete);
        Task UpdateClientAsync(Client clientToUpdate, Client client);
    }
}