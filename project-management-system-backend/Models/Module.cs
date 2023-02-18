namespace project_management_system_backend.Models
{
    public class Module:BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public ICollection<ModuleTask> TaskId { get; set; }

    }
}
