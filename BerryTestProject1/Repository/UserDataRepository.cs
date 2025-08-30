using BerryTestProject1.Data;
using BerryTestProject1.Interfaces;
using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BerryTestProject1.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserSessionService _userSessionService;

        public UserDataRepository(AppDbContext context, IUserSessionService userSessionService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userSessionService = userSessionService;
        }

        public async Task<UserRegistrationVM?> GetUserDataByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                var dbData = await _context.UserData.FindAsync(id);
                return dbData != null ? UserDataMapper.ToViewModel(dbData) : null;
            }
            catch (Exception ex)
            {
                // Consider using ILogger instead of Console.WriteLine in production
                Console.WriteLine($"[GetUserDataByIdAsync] Error: {ex.Message}");
                return null;
            }
        }

        public async Task<UserDetailsVM?> GetUserDataByNameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            try
            {
                var dbData = await _context.UserData
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Username == username);

                if(dbData != null)
                {
                    return new UserDetailsVM
                    {
                        Username = dbData.Username,
                        FullName = dbData.FullName,
                        Password = dbData.PasswordHash,
                        Email = dbData.Email
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetUserDataByNameAsync] Error: {ex.Message}");
                return null;
            }
            return null;
        }

        public async Task<IEnumerable<UserRegistrationVM?>> GetAllUsersAsync()
        {
            try
            {
                var dbData = await _context.UserData.AsNoTracking().ToListAsync();
                return dbData.Select(UserDataMapper.ToViewModel).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllUsersAsync] Error: {ex.Message}");
                return Enumerable.Empty<UserRegistrationVM>();
            }
        }

        public async Task AddAsync(UserRegistrationVM user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            UserData data = UserDataMapper.ToEntity(user);
            await _context.UserData.AddAsync(data);
            await SaveChangesAsync();
        }

        public async Task Update(UserRegistrationVM user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            UserData data = UserDataMapper.ToEntity(user);
            _context.UserData.Update(data);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.UserData.FindAsync(id);
            if (user != null)
                _context.UserData.Remove(user);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
