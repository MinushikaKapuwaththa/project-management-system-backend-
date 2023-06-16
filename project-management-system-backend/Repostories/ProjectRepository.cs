using Microsoft.EntityFrameworkCore;
using project_management_system_backend.Data;
using project_management_system_backend.Models;
using project_management_system_backend.Repositories;
using Task = System.Threading.Tasks.Task;

namespace project_management_system_backend.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApiDbContext _context;

        public ProjectRepository(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Project> GetProjectAsync(int projectId)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Projects.OrderBy(p => p.ProjectId).ToListAsync();
        }

        public async Task CreateProjectAsync(Project projectToCreate)
        {
            projectToCreate.ClientId = projectToCreate.ClientId == 0 ? null : projectToCreate.ClientId;
            _context.Projects.Add(projectToCreate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project projectToDelete)
        {
           
            var associatedDocs = _context.Documents.Where(d => d.ProjectId == projectToDelete.ProjectId);

           
            _context.Documents.RemoveRange(associatedDocs);

            _context.Projects.Remove(projectToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project oldProject, Project newProject)
        {
            newProject.ClientId = newProject.ClientId == 0 ? null : newProject.ClientId;
            oldProject.Name = newProject.Name;
            oldProject.Key = newProject.Key;
            oldProject.Description = newProject.Description;
            oldProject.ClientId = newProject.ClientId;
            oldProject.ReportedBy = newProject.ReportedBy;
            oldProject.EstimatedTime = newProject.EstimatedTime;
            oldProject.StartDate = newProject.StartDate;
            oldProject.EndDate = newProject.EndDate;
            oldProject.Budget = newProject.Budget;
            oldProject.HourlyRate = newProject.HourlyRate;
            oldProject.Lead = newProject.Lead;
            oldProject.Status = newProject.Status;

            _context.Projects.Update(oldProject);
            await _context.SaveChangesAsync();
        }
    }
}
