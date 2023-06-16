using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Dtos.ProjectDtos;
using project_management_system_backend.Dtos;
using project_management_system_backend.Repositories;
//using project_management_system_backend.Dtos.TaskDtos;

namespace project_management_system_backend.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        //private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            //_taskRepository = taskRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {
            var projects = await _projectRepository.GetProjectsAsync();

            return Ok(_mapper.Map<List<ProjectDto>>(projects));
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectDto>> GetProjectAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectAsync(projectId);

            return Ok(_mapper.Map<ProjectDto>(project));
        }


        [HttpPost]
        public async Task<ActionResult> CreateProject(ProjectForCreationDto project)
        {
            var projectToCreate = _mapper.Map<Models.Project>(project);

            await _projectRepository.CreateProjectAsync(projectToCreate);

            return Ok();
        }


        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var projectToDelete = await _projectRepository.GetProjectAsync(projectId);

            if (projectToDelete == null)
            {
                return NotFound();
            }

            await _projectRepository.DeleteProjectAsync(projectToDelete);

            return NoContent();
        }


        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, ProjectForUpdateDto project)
        {
            var projectToUpdate = await _projectRepository.GetProjectAsync(projectId);

            if (projectToUpdate == null)
            {
                return NotFound();
            }

            await _projectRepository.UpdateProjectAsync(projectToUpdate, _mapper.Map<Models.Project>(project));

            return NoContent();
        }


        /// <summary>
        /// OPTIONAL -  can remove if  don't need (Remive the functionality from front end as well)
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        //[HttpPost("AddTask")]
        //public async Task<ActionResult> CreateTaskAsync(TaskForCreationDto task)
        //{
        //    var taskToCreate = _mapper.Map<Models.Task>(task);

        //    await _taskRepository.CreateTaskAsync(taskToCreate);

        //    return Ok();
        //}

        [HttpGet("GetProjectsForDropdown")]
        public async Task<ActionResult<DropdownDto>> GetProjectsForDropdownAsync()
        {
            var projects = await _projectRepository.GetProjectsAsync();

            //This is for dropdowns in front end
            var result = projects.Select(c => new DropdownDto
            {
                Name = c.Name,
                Value = c.ProjectId
            });

            return Ok(result);
        }
    }
}
