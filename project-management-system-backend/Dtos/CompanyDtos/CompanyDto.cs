namespace project_management_system_backend.Dtos.CompanyDtos
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public byte Status { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyEmail { get; set; }
        public DateTime StartDate { get; set; }
    }
}
