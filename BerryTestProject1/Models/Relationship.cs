using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BerryTestProject1.Berry.Core;

namespace BerryTestProject1.Models
{
    public class Relationship
    {
        [Key]
        public int RelationshipId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string PersonName { get; set; } = string.Empty;
        public Gender PersonGender { get; set; }

        [Required]
        public int YearsKnown { get; set; }
        [Required]
        public InteractionFrequency InteractionFrequency { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public UserData User { get; set; } = null!;
        public ICollection<Response> Responses { get; set; } = new List<Response>();
        public Score? Score { get; set; }
    }

}