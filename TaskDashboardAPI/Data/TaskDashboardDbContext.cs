using Microsoft.EntityFrameworkCore;
using TaskDashboardAPI.Models.Entities;

namespace UserManagementAPI.Data
{
    public class TaskDashboardDbContext : DbContext
    {
        public TaskDashboardDbContext(DbContextOptions<TaskDashboardDbContext> options) : base(options) { }
        public DbSet<DashboardData> DashboardData { get; set; }
    }
}
