using project_management_system_backend.Models;
using Task = System.Threading.Tasks.Task;

namespace project_management_system_backend.Repositories 
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectAsync(int projectId);
        Task CreateProjectAsync(Project projectToCreate);
        Task DeleteProjectAsync(Project projectToDelete);
        Task UpdateProjectAsync(Project oldProject, Project newProject);
    }
}
