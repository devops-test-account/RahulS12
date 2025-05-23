using Microsoft.EntityFrameworkCore;
using TaskCreationAPI.Models.Entities;
namespace UserManagementAPI.Data
{
    public class TaskCreationDbContext : DbContext
    {
        public TaskCreationDbContext(DbContextOptions<TaskCreationDbContext> options) : base(options) { }
        public DbSet<TaskManager> Tasks { get; set; }
    }
}