using BerryTestProject1.Interfaces;
using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;
namespace BerryTestProject1.Services
{
    public class PersonDetailsService(IPersonDetailsRepository relationshipRepository, IUserSessionService userSession) : IPersonDetailsService
    {
        private readonly IPersonDetailsRepository _relationshipRepository = relationshipRepository;
        private readonly IUserSessionService _userSession = userSession;
        private static readonly Random _random = new();

        public async Task AddPersonAsync(PersonDetailsVM data)
        {
            try
            {
                if(!String.IsNullOrEmpty(data.PersonName) && data.YearsKnown > 0)
                {
                    data.UserId = Convert.ToInt32(_userSession.GetUserId());
                    await _relationshipRepository.AddPersonAsync(data);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        public async Task<List<Statement>> GetRandomStatementsAsync(string name)
        {
            try
            {
                var statements = await _relationshipRepository.GetAllStatementsAsync();
                int n = statements.Count;
                List<Statement> statements1 = new List<Statement>();
                statements1.Add(statements[0]);
                statements1.Add(statements[1]);
                return statements1;
                /*while (n >= 1)
                {
                    n--;
                    int k = _random.Next(n + 1);
                    (statements[n], statements[k]) = (statements[k], statements[n]);
                    statements[n].AssertiveStatement =statements[n].AssertiveStatement.
                        Replace("{name}", name);
                }
                return statements; */
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return await Task.FromResult(new List<Statement>());
            }
        }

        public async Task SaveResponses(List<UserResponseVM> Responses)
        {
            try
            {
                List<Response> data = new List<Response>();
                int id = Convert.ToInt32(_userSession.GetUserId());
                int PersonId =  await _relationshipRepository.GetPersonbyUserIdAsync(id);
                if (Responses != null && Responses.Count > 0)
                {
                    foreach (var response in Responses)
                    {
                        data.Add(new Response
                        {
                            PersonDetailsId = PersonId,
                            StatementId = response.StatementId,
                            Intensity = response.Intensity,
                        });
                    }
                    await _relationshipRepository.SaveUserResponsesAsync(data);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
