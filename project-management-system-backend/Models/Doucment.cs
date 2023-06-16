namespace project_management_system_backend.Models
{
    public class Doucment:BaseModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Attachment { get; set; }
        public ICollection<ReqirmentReqDoucment> ReqirmentReqs { get; set; }
    }
}
