using System.ComponentModel.DataAnnotations;

namespace TaskCreationAPI.Models.Entities
{
    public class TaskManager
    {

            [Key]
            public int Id { get; set; }
            [Required]
            [MaxLength(255)]
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? DueDate { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
