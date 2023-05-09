using System.ComponentModel.DataAnnotations.Schema;

namespace project_management_system_backend.Models
{
    public class ClientCompany : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? OwnerName { get; set; }
        public string? Status { get; set; }
        public string? ContactNumber { get; set; }
        public string? CompanyEmail { get; set; }
        public DateTime StartDate { get; set; }
    }


}