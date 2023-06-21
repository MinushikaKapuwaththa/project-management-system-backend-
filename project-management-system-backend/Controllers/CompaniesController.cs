using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Dtos;
using project_management_system_backend.Dtos.CompanyDtos;
using project_management_system_backend.Repositories;

namespace project_management_system_backend.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDto>>> GetCompanies()
        {
            var companies = await _companyRepository.GetCompaniesAsync();

            return Ok(_mapper.Map<List<CompanyDto>>(companies));
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyAsync(int companyId)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId);

            return Ok(_mapper.Map<CompanyDto>(company));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompanyAsync(CompanyForCreationDto company)
        {
            var companyToCreate = _mapper.Map<Models.Company>(company);

            await _companyRepository.CreateCompanyAsync(companyToCreate);

            return Ok();
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            var companyToDelete = await _companyRepository.GetCompanyAsync(companyId);

            if (companyToDelete == null)
            {
                return NotFound();
            }

            await _companyRepository.DeleteCompanyAsync(companyToDelete);

            return NoContent();
        }


        [HttpPut("{companyId}")]
        public async Task<IActionResult> UpdateCompany(int companyId, CompanyForUpdateDto project)
        {
            var companyToUpdate = await _companyRepository.GetCompanyAsync(companyId);

            if (companyToUpdate == null)
            {
                return NotFound();
            }

            await _companyRepository.UpdateCompanyAsync(companyToUpdate, _mapper.Map<Models.Company>(project));

            return NoContent();
        }


        [HttpGet("GetCompaniesForDropdown")]
        public async Task<ActionResult<DropdownDto>> GetCompaniesForDropdownAsync()
        {
            var company  = await _companyRepository.GetCompaniesAsync();

            //This is for dropdowns in front end
            var result = company.Select(c => new DropdownDto
            {
                Name = c.CompanyName,
                Value = c.CompanyId
            });

            return Ok(result);
        }
    }
}
