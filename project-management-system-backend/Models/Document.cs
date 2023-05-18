using project_management_system_backend.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace project_management_system_backend.Models
{
    public class Document
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [Range(1, 4)]
        public DocumentTypeEnum Type { get; set; }

        [Required]
        [MaxLength(250)]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Company { get; set; }

        [Required]
        public StatusEnum Status { get; set; }

        [MaxLength(5000)]
        public string FilePath { get; set; }

        [Required]
        public DateTime UploadTime { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ActualFileName { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }

        //foreign key to project
        public virtual Project? Project { get; set; }
    }
}
    

