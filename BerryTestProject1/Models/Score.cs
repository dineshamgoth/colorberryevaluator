using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryTestProject1.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }

        [ForeignKey("Relationship")]
        public int RelationshipId { get; set; }

        [Required]
        public double FinalScore { get; set; }

        [ForeignKey("ResultCategory")]
        public int ResultCategoryId { get; set; }

        public DateTime EvaluatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Relationship Relationship { get; set; } = null!;
        public ResultCategory ResultCategory { get; set; } = null!;
    }
}
