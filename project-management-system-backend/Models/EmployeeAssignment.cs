namespace project_management_system_backend.Models
{
    public class EmployeeAssignment:BaseModel
    {
        public int Id { get;set; }
        
        public Employee Employee{ get; set; }
        public Assignment Assigment { get; set; }


    }
}
