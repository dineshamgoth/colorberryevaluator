using BerryTestProject1.Berry.Core;
using BerryTestProject1.Models;
public static class UserDataMapper
{
    public static UserData ToEntity(this UserRegistrationVM vm)
    {
        return new UserData
        {
            Username = vm.Username,
            Email = vm.Email,
            PasswordHash = vm.Password,
            FullName = vm.FullName,
            Gender = vm.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase)
                ? Gender.female
                : Gender.male
        };
    }

    public static UserRegistrationVM ToViewModel(this UserData entity)
    {
        return new UserRegistrationVM
        {
            Username = entity.Username,
            Email = entity.Email,
            FullName = entity.FullName,
            Gender = entity.Gender.ToString(),
            Password = entity.PasswordHash,
            ConfirmPassword = entity.PasswordHash
        };
    }
}
