using BerryTestProject1.Berry.Core;
using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;
namespace BerryTestProject1.Interfaces
{
    public interface IPersonDetailsRepository
    {
        Task AddPersonAsync(PersonDetailsVM person);
        Task UpdatePersonAsync(PersonDetailsVM person);
        Task<int> GetPersonbyUserIdAsync(int userId);
        Task<IEnumerable<PersonDetailsVM?>> GetAllPersonsAsync();
        Task DeletePersonAsync(int id);
        Task<List<Statement>> GetAllStatementsAsync();
        Task<bool> SaveUserResponsesAsync(List<Response> responses);
        InteractionFrequency GetInteractionFrequency(int personId);
        Dictionary<string, int> LoadStatementScores();
        string GetCategoryByStatement(int statementId);
        void saveFinalResult(FinalResultVM result, int PersonId);
        string getResultMessagebyId(int ResultId);
        (string UserName, string PersonName, Gender gender) GetDataByPersonId(int personId);
        int GetYearsKnownbyPersonId(int personId);
    }
}
