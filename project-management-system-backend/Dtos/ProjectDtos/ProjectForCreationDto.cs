namespace project_management_system_backend.Dtos.ProjectDtos
{
    public class ProjectForCreationDto
    {
        public string Name { get; set; }
        public string? Key { get; set; }
        public string Description { get; set; }
        public int? ClientId { get; set; }
        public string ReportedBy { get; set; }
        public string Type { get; set; }
        public string EstimatedTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Budget { get; set; }
        public int HourlyRate { get; set; }
        public string Lead { get; set; }
        public int Status { get; set; }
    }
}
