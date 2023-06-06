using project_management_system_backend.Data;
using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public class BudgetRepository: IBudgetRepository
    {
        private readonly ApiDbContext _context;

        public BudgetRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Budget>> GetAllBudgetDetails()
        {
            var budgetList = _context.budget.ToList();
            return budgetList;
        }
        public async Task<Budget> GetBudgetById(int Id)
        {
            var budget = _context.budget.Where(x => x.Id == Id).FirstOrDefault();
            return budget;
        }

        public async Task<Budget> GetBudgetByProjectId(int projectId)
        {
            var budget = _context.budget.Where(x => x.ProjectId == projectId).FirstOrDefault();
            return budget;
        }
        public async Task<Budget> CreateBudget(Budget budget)
        {
            //budget.yetToReceive = budget.TotalBudget;
            _context.budget.Add(budget);
            _context.SaveChanges();
            
            return budget;
        }
        public async Task<Budget> UpdateBudget(Budget budget)
        {
            var budgetToUpdate = GetBudgetById(budget.Id).Result;
            budgetToUpdate.ProjectId = budget.ProjectId;
            budgetToUpdate.TotalBudget = budget.TotalBudget;
            budgetToUpdate.HourlyCost=budget.HourlyCost;
            budgetToUpdate.Actualcost=budget.Actualcost;
            budgetToUpdate.Plannedcost=budget.Plannedcost;
            budgetToUpdate.Received=budget.Received;
            budgetToUpdate.yetToReceive=budget.yetToReceive;
            budgetToUpdate.Created=budget.Created;
            budgetToUpdate.Updated=budget.Updated;
            budgetToUpdate.IsDeleted=budget.IsDeleted;
            budgetToUpdate.Deleted=budget.Deleted;
            _context.budget.Update(budgetToUpdate);
            _context.SaveChanges();
            return budget;
        }
    }
}

