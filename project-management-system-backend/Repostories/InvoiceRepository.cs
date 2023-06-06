using project_management_system_backend.Data;
using project_management_system_backend.Models;

namespace project_management_system_backend.Repostories
{
    public class InvoiceRepository: IInvoiceRepository
    {
        private readonly ApiDbContext _context;

        public InvoiceRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Invoice>> GetAllInvoiceDetails()
        {
            var invoiceList = _context.invoice.ToList();
            return invoiceList;
        }
        public async Task<Invoice> GetInvoiceNo(int Id)
        {
            var invoice = _context.invoice.Where(x => x.Id == Id).FirstOrDefault();
            return invoice;
        }

        public async Task<List<Invoice>> GetAllInvoiceByClientId(int ClientId)
        {
            var invoice = _context.invoice.Where(x => x.ClientId == ClientId).ToList();
            return invoice;
        }
        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            _context.invoice.Add(invoice);
            _context.SaveChanges();
            return invoice;
        }
        public async Task<Invoice> UpdateInvoice(Invoice invoice)
        {
            var invoiceToUpdate =GetInvoiceNo(invoice.Id).Result;
            invoiceToUpdate.ClientId = invoice.ClientId;
            invoiceToUpdate.Created = invoice.Created;
            invoiceToUpdate.Updated = invoice.Updated;
            invoiceToUpdate.IsDeleted = invoice.IsDeleted;
            invoiceToUpdate.Deleted = invoice.Deleted;
            _context.invoice.Update(invoiceToUpdate);
            _context.SaveChanges();
            return invoice;
        }


    }
}
