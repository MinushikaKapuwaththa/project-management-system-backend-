namespace project_management_system_backend.Models
{
    public class History:BaseModel
    {
        public int Id { get; set; }
        public string HistoryName { get; set; }
        public string Type { get; set; }
        public int EditedBy { get; set; }
        public string Updated { get; set; }

    }
}
