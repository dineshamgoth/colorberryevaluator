using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BerryTestProject1.Berry.Core;

namespace BerryTestProject1.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }

        [ForeignKey("Relationship")]
        public int RelationshipId { get; set; }

        [ForeignKey("Statement")]
        public int StatementId { get; set; }

        [Required]
        public ResponseIntensity Intensity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Relationship Relationship { get; set; } = null!;
        public Statement Statement { get; set; } = null!;
    }
}
