using Microsoft.EntityFrameworkCore;
using project_management_system_backend.Data;
using project_management_system_backend.Models;
using project_management_system_backend.Repositories;
using Task = System.Threading.Tasks.Task;

namespace project_management_system_backend.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApiDbContext _context;
        public CompanyRepository(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _context.companies.OrderBy(c => c.CompanyId).ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            return await _context.companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
        }

        public async Task CreateCompanyAsync(Company companyToCreate)
        {
            _context.companies.Add(companyToCreate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(Company companyToDelete)
        {
            _context.companies.Remove(companyToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyAsync(Company oldCompany, Company company)
        {
            oldCompany.CompanyName = company.CompanyName;
            oldCompany.OwnerName = company.OwnerName;
            oldCompany.Status = company.Status;
            oldCompany.ContactNumber = company.ContactNumber;
            oldCompany.CompanyEmail = company.CompanyEmail;
            oldCompany.StartDate = company.StartDate;

            _context.companies.Update(oldCompany);
            await _context.SaveChangesAsync();
        }
    }
}
