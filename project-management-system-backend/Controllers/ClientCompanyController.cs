using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientCompanyController : ControllerBase
    {
        private readonly IClientCompanyRepository _clientCompanyRepository;
        public ClientCompanyController(IClientCompanyRepository clientCompanyRepository)
        {
            _clientCompanyRepository = clientCompanyRepository;
        }
        // GET api/<PojectController>/5
        [HttpGet]
        public IActionResult GetAllClientDetails()
        {
            try 
            {
                return Ok(_clientCompanyRepository.GetAllClientDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Id/{Id}")]
        public IActionResult GetClientId(int Id)
        {
            try
            {
                return Ok(_clientCompanyRepository.GetClientId(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientCompany clientCompany)
        {
            try
            {
                return Ok(_clientCompanyRepository.CreateClient(clientCompany));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateClient(ClientCompany clientCompany)
        {
            try
            {
                return Ok(_clientCompanyRepository.UpdateClient(clientCompany));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
