using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskAssignmentAPI.Models.Entities
{
    public class TaskAssignment
    {

        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
