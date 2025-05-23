using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserManagementAPI.Models.Entities;

namespace UserManagementAPI.Data
{

        public class UserManagementDbContext : DbContext
        {
            public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options) { }
            public DbSet<User> Users { get; set; }
        }
}
