using project_management_system_backend.Data;
using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public class ClientPersonRepository : IClientPersonRepository
    {
       
        
            private readonly ApiDbContext _context;

            public ClientPersonRepository(ApiDbContext context)
            {
                _context = context;
            }
            public async Task<List<Client>> GetAllClientsDetails()
            {
                var clientList  = _context.Clients.ToList();
                return clientList;
            }
            public async Task<Client> GetClientId(int Id)
            {
                var clientList = _context.Clients.Where(x => x.ClientId == Id).FirstOrDefault();
                return clientList;
            }
            public async Task<Client> CreateClient(Client client)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return client;
            }

            public async Task DeleteClient(Client clientToDelete)
            {
                _context.Clients.Remove(clientToDelete);
                await _context.SaveChangesAsync();
            }

            public async Task<Client> UpdateClient(Client client)
            {
                var ClientToUpdate = GetClientId(client.ClientId).Result;
                ClientToUpdate.ClientName = client.ClientName;
                ClientToUpdate.ClientType = client.ClientType;
                ClientToUpdate.Company = client.Company;
                ClientToUpdate.ContactNumber = client.ContactNumber;
                ClientToUpdate.Email = client.Email;
                ClientToUpdate.Country= client.Country;
                _context.Clients.Update(ClientToUpdate);
                _context.SaveChanges();
                return client;
            }


        }
    }

