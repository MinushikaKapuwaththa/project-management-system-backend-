using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using project_management_system_backend.Models;

namespace project_management_system_backend.Data
{
    public class ApiDbContext:DbContext
    {
        internal object client;

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Project> projects { get; set; }
        public DbSet<Budget> budget { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<History> history { get; set; }
        public DbSet<Module> modules { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<OverDueTime> overdue { get; set; }
        public DbSet<Payment> payments { get;set; }
        public DbSet<projectManager> projectManagers { get; set; }
        public DbSet<Requirment> requirments { get; set; }
        public DbSet<ModuleTask> tasks { get; set; }
        public DbSet<User> users { get;}
        public DbSet<Assignment> assignment { get; set; }
        public DbSet<ClientCompany> clientCompany { get; set; }
        public DbSet<Invoice> invoice { get; set; }
    }
}
