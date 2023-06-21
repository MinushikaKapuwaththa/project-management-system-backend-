namespace project_management_system_backend.Dtos.ClientDtos
{
    public class ClientForUpdateDto
    {
        public string ClientName { get; set; }
        public int ClientType { get; set; }
        public int CompanyId  { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
}
