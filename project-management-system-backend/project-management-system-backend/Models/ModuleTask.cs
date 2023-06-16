namespace project_management_system_backend.Models
{
    public class ModuleTask : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int AcutalTime { get; set; }
        public int EstimatedTime { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public ICollection<Assignment> AssiId { get; set; }
        public ICollection<History> HistoryId { get; set; }

    }
}
