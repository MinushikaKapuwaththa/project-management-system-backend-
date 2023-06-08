using project_management_system_backend.Data;
using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly ApiDbContext _context;

        public object GetBudgetByProjectId { get; private set; }

        public PaymentRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Payment>> GetAllPaymentsDetails()
        {
            var paymentList = _context.payments.ToList();
            return paymentList;
        }
        public async Task<Payment> GetPaymentById(int Id)
        {
            var payment = _context.payments.Where(x => x.Id == Id).FirstOrDefault();
            return payment;
        }
        public async Task<List<Payment>> GetPaymentByProjectId(int ProjectId)
        {
            var payment = _context.payments.Where(x => x.ProjectId == ProjectId).ToList();
            return payment;
        }
        public async Task<List<Payment>> GetPaymentByProjectId(int ProjectId)
        {
            var payment = _context.payment.Where(x => x.ProjectId == ProjectId).ToList();
            return payment;
        }
        public async Task<Payment> CreatePayment(Payment payment)
        {

            var budgetToUpdate = _context.budget.Where(x => x.ProjectId == payment.ProjectId).FirstOrDefault();
            if (budgetToUpdate != null && payment.amount <= budgetToUpdate.yetToReceive)
            {
                    _context.payment.Add(payment);
                    budgetToUpdate.Received += payment.amount;
                    budgetToUpdate.yetToReceive -= payment.amount;
                    _context.budget.Update(budgetToUpdate);
                    _context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
            return payment;

        }
        
        public async Task<Payment> Updatepayment(Payment payment)
        {
            var paymentToUpdate = GetPaymentById(payment.Id).Result;
            paymentToUpdate.Paidby = payment.Paidby;
            paymentToUpdate.ProjectId = payment.ProjectId;
            paymentToUpdate.PaymentType = payment.PaymentType;
            paymentToUpdate.amount = payment.amount;
            paymentToUpdate.attachment = payment.attachment;
            paymentToUpdate.Created = payment.Created;
            paymentToUpdate.Updated = payment.Updated;
            paymentToUpdate.IsDeleted = payment.IsDeleted;
            paymentToUpdate.Deleted = payment.Deleted;
            _context.payments.Update(paymentToUpdate);
            _context.SaveChanges();
            return payment;
        }
    }
}
