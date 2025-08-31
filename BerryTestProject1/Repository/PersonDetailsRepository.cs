using BerryTestProject1.Berry.Core;
using BerryTestProject1.Data;
using BerryTestProject1.Interfaces;
using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace BerryTestProject1.Repository
{
    public class PersonDetailsRepository(AppDbContext appContext) : IPersonDetailsRepository
    {
        private readonly AppDbContext _context = appContext ?? throw new ArgumentNullException(nameof(appContext));
        public async Task AddPersonAsync(PersonDetailsVM person)
        {
            try
            {
                PersonDetails data = PersonDetailsMapper.ToEntity(person);
                await _context.PersonDetails.AddAsync(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        public async Task UpdatePersonAsync(PersonDetailsVM person)
        {
            try
            {
                if (person == null)
                    throw new ArgumentNullException(nameof(person));
                PersonDetails data = PersonDetailsMapper.ToEntity(person);
                _context.PersonDetails.Update(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        public async Task<int> GetPersonbyUserIdAsync(int userId)
        {
            try
            {
                var latestRecord = await _context.PersonDetails
                    .AsNoTracking()
                    .Where(r => r.UserId == userId)
                    .OrderByDescending(r => r.CreatedAt)
                    .FirstOrDefaultAsync();

                return latestRecord?.PersonDetailsId ?? 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetPersonbyUserIdAsync] Error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return 0;
            }
        }



        public async Task<IEnumerable<PersonDetailsVM?>> GetAllPersonsAsync()
        {
            try
            {
                var dbData = await _context.PersonDetails.AsNoTracking().ToListAsync();
                return dbData.Select(PersonDetailsMapper.ToViewModel).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllUsersAsync] Error: {ex.Message}");
                return Enumerable.Empty<PersonDetailsVM>();
            }
        }
        public async Task DeletePersonAsync(int id)
        {
            var user = await _context.PersonDetails.FindAsync(id);
            if (user != null)
                _context.PersonDetails.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Statement>> GetAllStatementsAsync()
        {
            try
            {
                var statements = await _context.Statement.AsNoTracking().ToListAsync();
                return statements;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return new List<Statement>();
            }
        }

        public async Task SaveUserResponsesAsync(List<Response> responses)
        {
            try
            {
                if (responses != null && responses.Count > 0)
                {
                    await _context.Response.AddRangeAsync(responses);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
