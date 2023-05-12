using project_management_system_backend.Data;
using project_management_system_backend.Models;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace project_management_system_backend.Repostories
{
    public class ClientCompanyRepository : IClientCompanyRepository
    {
        private readonly ApiDbContext _context;

        public ClientCompanyRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<ClientCompany>> GetAllClientDetails()
        {
            var clientCompanyList = _context.clientCompany.ToList();
            return clientCompanyList;
        }
        public async Task<ClientCompany> GetClientId(int Id)
        {
            var clientCompanyList = _context.clientCompany.Where(x => x.Id == Id).FirstOrDefault();
            return clientCompanyList;
        }
        public async Task<ClientCompany> CreateClient(ClientCompany clientCompany)
        {
            _context.clientCompany.Add(clientCompany);
            _context.SaveChanges();
            return clientCompany;
        }

        public async Task DeleteClient(ClientCompany clientToDelete)
        {
            _context.clientCompany.Remove(clientToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientCompany> UpdateClient(ClientCompany clientCompany)
        {
            var ClientToUpdate = GetClientId(clientCompany.Id).Result;
            ClientToUpdate.CompanyName = clientCompany.CompanyName;
            ClientToUpdate.OwnerName = clientCompany.OwnerName;
            ClientToUpdate.Status = clientCompany.Status;
            ClientToUpdate.ContactNumber = clientCompany.ContactNumber;
            ClientToUpdate.CompanyEmail = clientCompany.CompanyEmail;
            ClientToUpdate.StartDate = DateTime.Now;
            _context.clientCompany.Update(ClientToUpdate);
            _context.SaveChanges();
            return clientCompany;
        }

    }
}
