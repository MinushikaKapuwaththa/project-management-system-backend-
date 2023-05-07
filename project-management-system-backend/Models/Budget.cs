namespace project_management_system_backend.Models
{
    public class Budget:BaseModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TotalBudget { get; set; }  
        public int HourlyCost { get; set; }
        public int Actualcost { get; set; }
        public int Plannedcost { get; set; }
        public int Received { get; set; }
        public int yetToReceive { get; set; }
        


    }
}
