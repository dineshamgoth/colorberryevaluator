using BerryTestProject1.Berry.Core;
using BerryTestProject1.core;
using BerryTestProject1.Models;
namespace BerryTestProject1.ViewModels
{
    public class FinalResultVM
    {
        public double FinalScore { get; set; }
        public FinalResultCategory ResultCategory { get; set; } = FinalResultCategory.OuterCircle;
        public string ImageURI { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
    }
}
