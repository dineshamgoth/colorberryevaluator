using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BerryTestProject1.Berry.Core;

namespace BerryTestProject1.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }

        [ForeignKey("PersonDetails")]
        public int PersonDetailsId { get; set; }

        [ForeignKey("Statement")]
        public int StatementId { get; set; }

        [Required]
        public ResponseIntensity Intensity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation
        public PersonDetails PersonDetails { get; set; } = null!;
        public Statement Statement { get; set; } = null!;
    }
}
