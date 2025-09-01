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

        public async Task<bool> SaveUserResponsesAsync(List<Response> responses)
        {
            bool flag = false;
            try
            {
                if (responses != null && responses.Count > 0)
                {
                    await _context.Response.AddRangeAsync(responses);
                    await _context.SaveChangesAsync();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return flag;
        }

        public InteractionFrequency GetInteractionFrequency(int personId)
        {
            try
            {
                var person = _context.PersonDetails.Where(p => p.PersonDetailsId == personId)
                .OrderByDescending(p => p.CreatedAt).FirstOrDefault();
                return person?.InteractionFrequency ?? InteractionFrequency.rarely;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetInteractionFrequency] Error: {ex.Message}");
                return InteractionFrequency.rarely;
            }
        }

        public Dictionary<string, int> LoadStatementScores()
        {
            try
            {
                return _context.Statement.ToDictionary(c => c.Category, c => c.Score);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoadStatementScores] Error: {ex.Message}");
                return new Dictionary<string, int>();
            }
        }

        public string GetCategoryByStatement(int statementId)
        {
            try
            {
                return _context.Statement
                    .Where(s => s.StatementId == statementId)
                    .Select(s => s.Category)
                    .FirstOrDefault() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetCategoryByStatement] Error: {ex.Message}");
                return string.Empty;
            }
        }

        public void saveFinalResult(FinalResultVM result, int PersonId)
        {
            try
            {
                if(result != null)
                {
                    Score data = new()
                    {
                        PersonDetailsId = PersonId,
                        FinalScore = result.FinalScore,
                        ResultCategoryId = Convert.ToInt32(result.ResultCategory),
                    };
                    _context.Score.Add(data);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        public string getResultMessagebyId(int ResultId)
        {
            string message = String.Empty;
            try
            {
                 message = _context.ResultCategory
                .Where(r => r.ResultCategoryId == ResultId)
                .Select(r => r.Message)
                .FirstOrDefault() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return message;
        }

        public Dictionary<string, string> GetNamesByPersonId(int personId)
        {
            try
            {
                var result = (from p in _context.PersonDetails
                              join u in _context.UserData on p.UserId equals u.UserId
                              where p.PersonDetailsId == personId
                              select new
                              {
                                  p.PersonName,
                                  u.FullName
                              }).FirstOrDefault();

                return result == null
                    ? new Dictionary<string, string>()
                    : new Dictionary<string, string>
                    {
                        { "UserName", result.FullName },
                        { "PersonName", result.PersonName }
                    };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  // better to log properly in production
                return new Dictionary<string, string>(); // safe fallback
            }
        }

        public int GetYearsKnownbyPersonId(int personId)
        {
            try
            {
                return _context.PersonDetails.Where(p => p.PersonDetailsId == personId)
                    .Select(p => p.YearsKnown).FirstOrDefault();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

    }
}
