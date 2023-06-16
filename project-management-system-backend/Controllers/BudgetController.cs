using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;
        public BudgetController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        // GET api/<PojectController>/5
        [HttpGet]
        public IActionResult GetAllBudgetDetails()
        {
            try
            {
                return Ok(_budgetRepository.GetAllBudgetDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Id/{Id}")]
        public IActionResult GetBudgetById(int Id)
        {
            try
            {
                return Ok(_budgetRepository.GetBudgetById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ProjectId/{projectId}")]
        public IActionResult GetBudgetByProjectId(int projectId)
        {
            try
            {
                return Ok(_budgetRepository.GetBudgetByProjectId(projectId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateBudget([FromBody] Budget budget)
        {
            try
            {
                return Ok(_budgetRepository.CreateBudget(budget));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateBudget(Budget budget)
        {
            try
            {
                return Ok(_budgetRepository.UpdateBudget(budget));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
