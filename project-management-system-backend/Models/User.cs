namespace project_management_system_backend.Models
{
    public class User:BaseModel
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public int Password { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string EmailConfirmed { get; set; }
        public String NIC { get; set; }

    }


    }

