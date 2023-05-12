using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectByID(int id);
        Task<Project> CreatProject(Project project);
        Task DeleteProject(Project projectToDelete);
        Task<Project> UpdateProject(Project project);
    }
}
