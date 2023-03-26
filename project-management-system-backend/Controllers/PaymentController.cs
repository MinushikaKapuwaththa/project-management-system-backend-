using Microsoft.AspNetCore.Mvc;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;

namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _PaymentRepository;
        public PaymentController(IPaymentRepository PaymentRepository)
        {
            _PaymentRepository = PaymentRepository;
        }
        // GET api/<PojectController>/5
        [HttpGet]
        public IActionResult GetAllPaymentsDetails()
        {
            try
            {
                return Ok(_PaymentRepository.GetAllPaymentsDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetPaymentById(string Id)
        {
            try
            {
                return Ok(_PaymentRepository.GetPaymentById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Createpayment([FromBody] Payment payment)
        {
            try
            {
                return Ok(_PaymentRepository.CreatePayment(payment));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Updatepayment(Payment payment)
        {
            try
            {
                return Ok(_PaymentRepository.Updatepayment(payment));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
