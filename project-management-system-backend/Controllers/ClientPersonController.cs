using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientPersonController : ControllerBase
    {
        private readonly IClientPersonRepository _clientPersonRepository;
        private object clientToDelete;

        public ClientPersonController(IClientPersonRepository clientPersonRepository)
        {
            _clientPersonRepository = clientPersonRepository;
        }
        // GET api/<PojectController>/5
        [HttpGet]
        public IActionResult GetAllClientDetails()
        {
            try
            {
                return Ok(_clientPersonRepository.GetAllClientsDetails());
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
                return Ok(_clientPersonRepository.GetClientId(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] Client client)
        {
            try
            {
                return Ok(_clientPersonRepository.CreateClient(client));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var clientToDelete = await _clientPersonRepository.GetClientId(id);

            if (clientToDelete == null)
            {
                return NotFound();
            }

            await _clientPersonRepository.DeleteClient(clientToDelete);

            return NoContent();
        }




        [HttpPut]
        [Route("update")]
        public IActionResult UpdateClient(Client client)
        {
            try
            {
                return Ok(_clientPersonRepository.UpdateClient(client));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
