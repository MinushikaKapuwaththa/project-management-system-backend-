using project_management_system_backend.Models;

namespace project_management_system_backend.VIewModels
{
    public class GetModuleTasksViewModel
    {
        public Module module { get; set; }
        public List<ModuleTask> tasks { get; set; }
    }
}
