using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Dtos.ClientDtos;
using project_management_system_backend.Dtos;
using project_management_system_backend.Repositories;

namespace project_management_system_backend.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetClientsAsync()
        {
            var clients = await _clientRepository.GetClientsAsync();

            return Ok(_mapper.Map<List<ClientDto>>(clients));
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<ClientDto>> GetClientAsync(int clientId)
        {
            var client = await _clientRepository.GetClientAsync(clientId);

            return Ok(_mapper.Map<ClientDto>(client));
        }

        [HttpPost]
        public async Task<ActionResult> CreateClientAsync(ClientForCreationDto client)
        {
            var clientToCreate = _mapper.Map<Models.Client>(client);

            await _clientRepository.CreateClientAsync(clientToCreate);

            return Ok();
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClientAsync(int clientId)
        {
            var clientToDelete = await _clientRepository.GetClientAsync(clientId);

            if (clientToDelete == null)
            {
                return NotFound();
            }

            await _clientRepository.DeleteClientAsync(clientToDelete);

            return NoContent();
        }


        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClientAsync(int clientId, ClientForUpdateDto client)
        {
            var clientToUpdate = await _clientRepository.GetClientAsync(clientId);

            if (clientToUpdate == null)
            {
                return NotFound();
            }

            await _clientRepository.UpdateClientAsync(clientToUpdate, _mapper.Map<Models.Client>(client));

            return NoContent();
        }

        [HttpGet("GetClientsForDropdown")]
        public async Task<ActionResult<DropdownDto>> GetClientForDropdownAsync()
        {
            var clients = await _clientRepository.GetClientsAsync();

            //This is for dropdowns in front end
            var result = clients.Select(c => new DropdownDto
            {
                Name = c.ClientName,
                Value = c.ClientId
            });

            return Ok(result);
        }
    }
}
