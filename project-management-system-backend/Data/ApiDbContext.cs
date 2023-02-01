using Microsoft.EntityFrameworkCore;
using project_management_system_backend.Models;

namespace project_management_system_backend.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Project> projects { get; set; }
    }
}
