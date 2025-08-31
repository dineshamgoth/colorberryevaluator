using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryTestProject1.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }

        [ForeignKey("PersonDetails")]
        public int PersonDetailsId { get; set; }

        [Required]
        public double FinalScore { get; set; }

        [ForeignKey("ResultCategory")]
        public int ResultCategoryId { get; set; }

        public DateTime EvaluatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation
        public PersonDetails PersonDetails { get; set; } = null!;
        public ResultCategory ResultCategory { get; set; } = null!;
    }
}
