using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllInvoiceDetails();
        Task<List<Invoice>> GetAllInvoiceByClientId(int Id);
        Task<Invoice > GetInvoiceNo(int Id);
        Task<Invoice > CreateInvoice(Invoice invoice);
        Task<Invoice > UpdateInvoice(Invoice invoice);                                          
    }
}
