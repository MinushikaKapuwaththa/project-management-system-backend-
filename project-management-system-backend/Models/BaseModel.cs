namespace project_management_system_backend.Models
{
    public class BaseModel
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool  IsDeleted { get; set; }
        public DateTime Deleted { get; set; }

    }
}