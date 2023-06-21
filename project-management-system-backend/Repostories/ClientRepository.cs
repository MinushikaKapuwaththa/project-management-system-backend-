using Microsoft.EntityFrameworkCore;
using project_management_system_backend.Data;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Task = System.Threading.Tasks.Task;

namespace project_management_system_backend.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApiDbContext _context;
        public ClientRepository(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateClientAsync(Client clientToCreate)
        {
            clientToCreate.CompanyId = clientToCreate.CompanyId == 0 ? null : clientToCreate.CompanyId;
            _context.Clients.Add(clientToCreate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(Client clientToDelete)
        {
            //Need to remove associated Projects first
            var associateProjects = _context.Projects.Where(p => p.ClientId == clientToDelete.ClientId);
            _context.Projects.RemoveRange(associateProjects);
            _context.Clients.Remove(clientToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            return await _context.Clients.OrderBy(c => c.ClientId).ToListAsync();
        }

        public async Task<Client> GetClientAsync(int clientId)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);
        }

        public async Task UpdateClientAsync(Client clientToUpdate, Client client)
        {
            client.CompanyId = client.CompanyId == 0 ? null : client.CompanyId; 
            clientToUpdate.ClientName = client.ClientName;
            clientToUpdate.CompanyId  = client.CompanyId;
            clientToUpdate.ClientType = client.ClientType;
            clientToUpdate.ContactNumber = client.ContactNumber;
            clientToUpdate.Email = client.Email;
            clientToUpdate.Country = client.Country;

            _context.Clients.Update(clientToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
