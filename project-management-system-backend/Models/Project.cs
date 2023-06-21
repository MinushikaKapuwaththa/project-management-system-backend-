using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using project_management_system_backend.Enums;
using project_management_system_backend.Models;

namespace project_management_system_backend.Models 
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        //[MaxLength(200)]
        //public string? Key { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(500)]
        public string ReportedBy { get; set; }

        [Required]
        [MaxLength(250)]
        public string Type { get; set; }

        public string EstimatedTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Budget { get; set; }
        public int HourlyRate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Lead { get; set; }

        [Required]
        [Range(1, 4)]
        public ProjectStatusEnum Status { get; set; }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }

        //Foreign Key to Client
        public virtual Client? Client { get; set; }
    }
}
