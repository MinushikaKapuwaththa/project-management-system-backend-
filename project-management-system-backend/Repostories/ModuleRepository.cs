using project_management_system_backend.Data;
using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApiDbContext _context;

        public ModuleRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Module>> GetAllModules()
        {
            var moduleList = _context.modules.ToList();
            return moduleList;
        }
        public async Task<Module> GetModuleByID(int id)
        {
            var module = _context.modules.Where(x => x.Id == id).FirstOrDefault();
            return module;
        }
        public async Task<Module> CreatModule(Module module)
        {
            _context.modules.Add(module);
            _context.SaveChanges();
            return module;
        }
        public async Task<Module> UpdateModule(Module module)
        {
            var moduleToUpdate = GetModuleByID(module.Id).Result;
            moduleToUpdate.Name = module.Name;
            moduleToUpdate.Description = module.Description;
            moduleToUpdate.IsDeleted = false;
            moduleToUpdate.Created = DateTime.Now;
            moduleToUpdate.Updated = DateTime.Now;
            moduleToUpdate.Priority = module.Priority;
            moduleToUpdate.Tasks = module.Tasks;
            moduleToUpdate.Status = module.Status;
            moduleToUpdate.EndDate = module.EndDate;
            moduleToUpdate.StartDate = module.StartDate;
            _context.modules.Update(moduleToUpdate);
            _context.SaveChanges();
            return module;
        }

        public async Task DeleteModule(int id)
        {
            var moduleToDelete = GetModuleByID(id);
            _context.modules.Remove(moduleToDelete.Result);
            _context.SaveChanges();
        }
        //public async List<ModuleTask> GetTasksByModuleId(int moduleId)
        //{
        //    var tasks = new List<ModuleTask>();

        //    //var moduleList = _context.;
        //}

    }
}
