using Microsoft.EntityFrameworkCore;
using TaskAssignmentAPI.Models.Entities;

namespace UserManagementAPI.Data
{
    public class TaskAssignmentDbContext : DbContext
    {
        public TaskAssignmentDbContext(DbContextOptions<TaskAssignmentDbContext> options) : base(options) { }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
    }
}
