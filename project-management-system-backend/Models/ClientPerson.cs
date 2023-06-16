namespace project_management_system_backend.Models
{
    public class Client:BaseModel
    {
        public int CPID { get; set; }
        public string ClientName { get; set; }
        public string Position { get; set; }

    }
}
