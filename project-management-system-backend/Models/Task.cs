//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;


//namespace project_management_system_backend.Models 
//{
//    public class Task
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int TaskId { get; set; }

//        [Required]
//        [MaxLength(500)]
//        public string TaskName { get; set; }

//        [MaxLength(500)]
//        public string Description { get; set; }

//        [Required]
//        [MaxLength(250)]
//        public int EstimatedTime { get; set; }
//        public bool? State { get; set; }

//        [Required]
//        public DateTime Deadline { get; set; }

//        [ForeignKey("Project")]
//        public int? ProjectId { get; set; }

//        //Foreign Key to Project
//        public virtual Project? Project { get; set; }
//    }
//}
