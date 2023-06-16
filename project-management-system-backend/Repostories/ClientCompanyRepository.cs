using project_management_system_backend.Data;
using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public class ClientCompanyRepository: IClientCompanyRepository
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
        public async Task<ClientCompany> UpdateClient(ClientCompany clientCompany)
        {
            var clientToUpdate = GetClientId(clientCompany.Id).Result;
            clientToUpdate.CompanyName = clientCompany.CompanyName;
            clientToUpdate.CompanyAddress = clientCompany.CompanyAddress;
            clientToUpdate.Email = clientCompany.Email;
            clientToUpdate.PhoneNumber = clientCompany.PhoneNumber;
            clientToUpdate.Created = clientCompany.Created;
            clientToUpdate.Updated = clientCompany.Updated;
            clientToUpdate.IsDeleted = clientCompany.IsDeleted;
            clientToUpdate.Deleted = clientCompany.Deleted;
            _context.clientCompany.Update(clientToUpdate);
            _context.SaveChanges();
            return clientCompany;
        }

    }
}
