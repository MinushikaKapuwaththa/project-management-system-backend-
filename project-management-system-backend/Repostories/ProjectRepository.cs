using project_management_system_backend.Data;
using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly ApiDbContext _context;

        public ProjectRepository(ApiDbContext context)
        { 
            _context = context;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            var projectList = _context.projects.ToList();
            return projectList;
        }
        public async Task<Project> GetProjectByID(int id)
        {
            var project = _context.projects.Where(x=>x.ID == id).FirstOrDefault();
            return project;
        }
        public async  Task <Project> CreatProject(Project project)
        {
            _context.projects.Add(project);
            _context.SaveChanges();
            return project;
        }
        public async Task<Project> UpdateProject(Project project)
        {
            var projectToUpdate = GetProjectByID(project.ID).Result;
            projectToUpdate.Name = project.Name;
            projectToUpdate.Estimatetime = project.Estimatetime;
            projectToUpdate.actualtime = project.actualtime;
            projectToUpdate.Remainingtime = project.Remainingtime;
            projectToUpdate.Updated = DateTime.Now;
            _context.projects.Update(projectToUpdate);
            _context.SaveChanges();
            return project;
        }
    }
}
