using BerryTestProject1.Berry.Core;

namespace BerryTestProject1.ViewModels
{
    public class PersonDetailsVM
    {
        public int UserId { get; set; }
        public string? PersonName { get; set; }
        public int YearsKnown { get; set; }
        public InteractionFrequency Interaction { get; set; }
        public Gender Gender { get; set; }
    }
}
