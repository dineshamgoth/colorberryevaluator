using BerryTestProject1.Interfaces;
using BerryTestProject1.ViewModels;

namespace BerryTestProject1.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserDataRepository _userDataRepository;

        public UserDataService(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        public Task<UserRegistrationVM?> GetUserDataByIdAsync(int id) => _userDataRepository.GetUserDataByIdAsync(id);

        public Task<UserDetailsVM?> GetUserByUsername(string username) => _userDataRepository.GetUserDataByNameAsync(username);

        public Task<IEnumerable<UserRegistrationVM?>> GetAllUsersAsync() => _userDataRepository.GetAllUsersAsync();

        public void RegisterUser(UserRegistrationVM user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _userDataRepository.AddAsync(user);
                _userDataRepository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateUser(UserRegistrationVM user)
        {
            try
            {
                _userDataRepository.Update(user);
                _userDataRepository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteUser(int id)
        {
            _userDataRepository.DeleteAsync(id);
            _userDataRepository.SaveChangesAsync();
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            try
            {
                var user = await GetUserByUsername(username);
                if (user != null)
                {
                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                    return isPasswordValid;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
