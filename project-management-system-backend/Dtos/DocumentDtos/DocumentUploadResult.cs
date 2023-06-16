namespace project_management_system_backend.Dtos.DocumentDtos
{
    public class DocumentUploadResult
    {
        public string Name { get; set; }
        public string ActualFileName { get; set; }
        public int Type { get; set; }
        public string ClientName { get; set; }
        public string Company { get; set; }
        public string DocumentPath { get; set; }
        public int Status { get; set; }
        public int? ProjectId { get; internal set; }
    }
}
