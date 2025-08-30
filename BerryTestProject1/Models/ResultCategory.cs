using System.ComponentModel.DataAnnotations;

namespace BerryTestProject1.Models
{
    public class ResultCategory
    {
        [Key]
        public int ResultCategoryId { get; set; }

        [Required, MaxLength(50)]
        public string CirclePlacement { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string ColorCode { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        // Navigation
        public ICollection<Score> Scores { get; set; } = new List<Score>();
    }
}
