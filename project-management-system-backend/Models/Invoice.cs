using System.ComponentModel.DataAnnotations;

namespace project_management_system_backend.Models
{
    public class Invoice : BaseModel
    {
        [Key]
        public string InvoiceNo { get; set; }
        public int ClientId { get; set;}
       }
}
