using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;

namespace BerryTestProject1.Berry.Core
{
    public static class PersonDetailsMapper
    {
        public static PersonDetails ToEntity(this PersonDetailsVM vm)
        {
            return new PersonDetails
            {
                UserId = vm.UserId,
                PersonName = vm.PersonName ?? string.Empty,
                YearsKnown = vm.YearsKnown,
                InteractionFrequency = vm.Interaction,
                Gender = vm.Gender
            };
        }
        public static PersonDetailsVM ToViewModel(this PersonDetails entity)
        {
            return new PersonDetailsVM
            {
                UserId = entity.UserId,
                PersonName = entity.PersonName,
                YearsKnown = entity.YearsKnown,
                Interaction = entity.InteractionFrequency,
                Gender = entity.Gender
            };
        }
    }
}
