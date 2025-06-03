using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;
        public ModuleController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }


        [HttpGet]
        public IActionResult GetAllModules()
        { 
            try
            {
                return Ok(_moduleRepository.GetAllModules());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("module/{id}")]
        public IActionResult GetModuleByID(int id)
        {
            try
            {
                return Ok(_moduleRepository.GetModuleByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateProject(Module module)
        {
            try
            {
                return Ok(_moduleRepository.CreatModule(module));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        [Route("/module/update")]
        public IActionResult updateproject(Module module)
        {
            try
            {
                return Ok(_moduleRepository.UpdateModule(module));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteModule(Module module)
        {
            try
            {
                return Ok(_moduleRepository.DeleteModule(module.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("/tasks-by-module/{id}")]
        //public IActionResult getTasksByModuleId()
        //{
        //    try
        //    {
        //        return Ok(_moduleRepository.GetTasksByModuleId());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
