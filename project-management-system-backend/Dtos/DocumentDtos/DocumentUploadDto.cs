namespace project_management_system_backend.Dtos.DocumentDtos
{
    public class DocumentUploadDto
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public string ClientId  { get; set; }
        public string Company { get; set; }
        public IFormFile File { get; set; }
        public int? ProjectId { get; set; }
    }
}
