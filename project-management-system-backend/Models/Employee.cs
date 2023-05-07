namespace project_management_system_backend.Models
{
    public class Employee:BaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string position { get; set; }
        public ICollection<EmployeeAssignment> EmployeeAssignments { get; set; }
    }
}
