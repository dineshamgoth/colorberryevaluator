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
        Task SaveUserResponsesAsync(List<Response> responses);
    }
}
