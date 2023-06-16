using project_management_system_backend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Task = System.Threading.Tasks.Task;

namespace project_management_system_backend.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyAsync(int companyId);
        Task CreateCompanyAsync(Company companyToCreate);
        Task DeleteCompanyAsync(Company companyToDelete);
        Task UpdateCompanyAsync(Company companyToUpdate, Company company);
    }
}
