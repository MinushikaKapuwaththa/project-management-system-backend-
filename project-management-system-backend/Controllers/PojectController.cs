using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        // GET api/<PojectController>/5
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                return Ok(_projectRepository.GetAllProjects());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetProjectByID(int id)
        {
            try
            {
                return Ok(_projectRepository.GetProjectByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            try
            {
                return Ok(_projectRepository.CreatProject(project));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        [Route("/update")]
        public IActionResult updateproject(Project project)
        {
            try
            {
                return Ok(_projectRepository.UpdateProject(project));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
