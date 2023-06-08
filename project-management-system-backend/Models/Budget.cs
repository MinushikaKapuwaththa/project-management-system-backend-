namespace project_management_system_backend.Models
{
    public class Budget:BaseModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public double TotalBudget { get; set; }  
        public double HourlyCost { get; set; }
        public double Actualcost { get; set; }
        public double Plannedcost { get; set; }
        public double Received { get; set; }
        public double yetToReceive { get; set; }

    }
}
