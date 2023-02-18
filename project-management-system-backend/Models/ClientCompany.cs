namespace project_management_system_backend.Models
{
    public class ClientCompany:BaseModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    
    
}
