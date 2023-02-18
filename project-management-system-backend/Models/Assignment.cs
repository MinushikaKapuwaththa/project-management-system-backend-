namespace project_management_system_backend.Models
{
    public class Assignment:BaseModel
    {
        public int Id { get; set; }
        public DateTime AssianedDate{ get; set; }
        public ICollection<EmployeeAssignment> EmployeeAssignments { get; set; }

    }
}
