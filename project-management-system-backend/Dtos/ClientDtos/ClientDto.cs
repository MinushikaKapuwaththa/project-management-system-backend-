using project_management_system_backend.Enums;

namespace project_management_system_backend.Dtos.ClientDtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ClientType { get; set; }

        public string ClientTypeName
        {
            get
            {
                return Enum.GetName((ClientTypeEnum)ClientType) ?? string.Empty;
            }
        }
        public string Company { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
}
