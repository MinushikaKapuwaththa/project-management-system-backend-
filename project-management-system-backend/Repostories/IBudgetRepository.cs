using project_management_system_backend.Models;

   
    public interface IBudgetRepository
    {
        Task<List<Budget> >GetAllBudgetDetails();
        Task<Budget> GetBudgetById(int Id);

        Task<Budget> GetBudgetByProjectId(int projectId);
        Task<Budget> CreateBudget(Budget budget);
        Task<Budget> UpdateBudget(Budget budget);
    }

 