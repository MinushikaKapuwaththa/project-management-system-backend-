﻿namespace project_management_system_backend.Models
{
    public class Module : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public List<ModuleTask> Tasks { get; set; }

    }
}
