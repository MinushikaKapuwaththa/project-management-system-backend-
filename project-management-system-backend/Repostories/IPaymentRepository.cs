using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public interface IPaymentRepository
    {       
        Task<List<Payment>> GetAllPaymentsDetails();
        Task<Payment> GetPaymentById(int Id);
        Task<List<Payment>> GetPaymentByProjectId(int ProjectId);
        Task<Payment> CreatePayment(Payment payment);
        Task<  Payment> Updatepayment(Payment payment);
    }
}
