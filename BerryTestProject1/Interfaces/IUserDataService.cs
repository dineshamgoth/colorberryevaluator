using BerryTestProject1.ViewModels;

namespace BerryTestProject1.Interfaces
{
    public interface IUserDataService
    {
        Task<UserRegistrationVM?> GetUserDataByIdAsync(int id);
        Task<UserDetailsVM?> GetUserByUsername(string username);
        Task<IEnumerable<UserRegistrationVM?>> GetAllUsersAsync();
        void RegisterUser(UserRegistrationVM user);
        void UpdateUser(UserRegistrationVM user);
        void DeleteUser(int id);
        Task<bool> AuthenticateUser(string username, string password);
    }
}
