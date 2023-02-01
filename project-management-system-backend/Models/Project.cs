namespace project_management_system_backend.Models
{
    public class Project:BaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Estimatetime { get; set; }
        public int actualtime { get; set; }
        public int Remainingtime { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
    }
}
    