using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PojectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        public PojectController(IProjectRepository projectRepository)
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
        
    }
}
