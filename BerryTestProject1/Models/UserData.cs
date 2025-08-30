using BerryTestProject1.Berry.Core;
using System.ComponentModel.DataAnnotations;

namespace BerryTestProject1.Models
{
    public class UserData
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, MaxLength(10)]
        public Gender Gender { get; set; }

        [EmailAddress, MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Relationship> Relationships { get; set; } = new List<Relationship>();
    }
}