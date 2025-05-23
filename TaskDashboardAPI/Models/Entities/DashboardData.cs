using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDashboardAPI.Models.Entities
{
    public class DashboardData
    {

        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int TaskCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
