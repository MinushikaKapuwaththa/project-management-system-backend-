namespace project_management_system_backend.Models
{
    public class OverDueTime:BaseModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string EstimatedTime { get; set; }
        public string AcualTime { get; set; }
        public string OverdueTime { get; set;}
    }
}
