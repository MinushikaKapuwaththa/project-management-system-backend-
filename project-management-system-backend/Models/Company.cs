using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace project_management_system_backend.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(250)]
        public string OwnerName { get; set; }

        [Required]
        public byte Status { get; set; }

        [Required]
        [MaxLength(250)]
        public string ContactNumber { get; set; }

        [MaxLength(500)]
        public string CompanyEmail { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}
