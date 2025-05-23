using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementAPI.Models.Entities
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
