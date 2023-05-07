using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetAllModules();
        Task<Module> GetModuleByID(int id);
        Task<Module> CreatModule(Module project);
        Task<Module> UpdateModule(Module project);
        Task<Module> DeleteModule(int id);
       
        // Task<List<ModuleTask>> GetTasksByModuleId(int moduleId);
    }
}
