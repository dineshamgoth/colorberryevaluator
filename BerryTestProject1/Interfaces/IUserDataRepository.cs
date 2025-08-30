using BerryTestProject1.ViewModels;

namespace BerryTestProject1.Interfaces
{
    public interface IUserDataRepository
    {
        Task<UserRegistrationVM?> GetUserDataByIdAsync(int id);
        Task<UserDetailsVM?> GetUserDataByNameAsync(string username);
        Task<IEnumerable<UserRegistrationVM?>> GetAllUsersAsync();
        Task AddAsync(UserRegistrationVM user);
        Task Update(UserRegistrationVM user);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
