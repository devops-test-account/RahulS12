using System.ComponentModel.DataAnnotations;

namespace TaskCreationAPI.Models
{
    public class DashboardUpdateDto
    {

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int TaskCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
