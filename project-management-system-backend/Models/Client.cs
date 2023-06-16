using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using project_management_system_backend.Enums;

namespace project_management_system_backend.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string ClientName { get; set; }

        [Required]
        [Range(1, 4)]
        public ClientTypeEnum ClientType { get; set; }

        [Required]
        [MaxLength(250)]
        public string Company { get; set; }

        [Required]
        [MaxLength(250)]
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Country { get; set; }
        public virtual List<Project> Projects { get; set; }
    


    }
}
