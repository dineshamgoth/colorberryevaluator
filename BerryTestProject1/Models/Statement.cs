using System.ComponentModel.DataAnnotations;

namespace BerryTestProject1.Models
{
    public class Statement
    {
        [Key]
        public int StatementId { get; set; }

        [Required, MaxLength(500)]
        public string AssertiveStatement { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // Navigation
        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }
}
