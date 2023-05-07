using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;        

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _InvoiceRepository;
        public InvoiceController(IInvoiceRepository InvoiceRepository)
        {
            _InvoiceRepository = InvoiceRepository;
        }
        // GET api/<PojectController>/5
        [HttpGet]
        public IActionResult GetAllInvoiceDetails()
        {
            try
            {
                return Ok(_InvoiceRepository.GetAllInvoiceDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("InvoiceNo/{InvoiceNo}")]
        public IActionResult GetBudgetById(string InvoiceNo)
        {
            try
            {
                return Ok(_InvoiceRepository.GetInvoiceNo(InvoiceNo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ClientId/{ClientId}")]
        public IActionResult GetAllInvoiceByClientId(int ClientId)
        {
            try
            {
                return Ok(_InvoiceRepository.GetAllInvoiceByClientId(ClientId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateInvoice([FromBody] Invoice invoice)
        {
            try
            {
                return Ok(_InvoiceRepository.CreateInvoice(invoice));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateInvoice(Invoice invoice)
        {
            try
            {
                return Ok(_InvoiceRepository.UpdateInvoice(invoice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
