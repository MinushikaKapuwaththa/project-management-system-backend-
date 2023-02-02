using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjects();
    }
}
