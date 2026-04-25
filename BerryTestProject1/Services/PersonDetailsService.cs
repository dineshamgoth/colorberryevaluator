using BerryTestProject1.Berry.Core;
using BerryTestProject1.Interfaces;
using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;
namespace BerryTestProject1.Services
{
    public class PersonDetailsService(IPersonDetailsRepository personDetailsRepository, IUserSessionService userSession) : IPersonDetailsService
    {
        private readonly IPersonDetailsRepository _personDetailsRepository = personDetailsRepository;
        private readonly IUserSessionService _userSession = userSession;
        private static readonly Random _random = new();

        public async Task AddPersonAsync(PersonDetailsVM data)
        {
            try
            {
                if(!String.IsNullOrEmpty(data.PersonName) && data.YearsKnown > 0)
                {
                    data.UserId = Convert.ToInt32(_userSession.GetUserId());
                    await _personDetailsRepository.AddPersonAsync(data);
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
                var statements = await _personDetailsRepository.GetAllStatementsAsync();
                int n = statements.Count;
                //Testing purpose
                /*List<Statement> statements1 = new List<Statement>();
                statements1.Add(statements[0]);
                statements1.Add(statements[1]);
                return statements1;*/
                while (n >= 1)
                {
                    n--;
                    int k = _random.Next(n + 1);
                    (statements[n], statements[k]) = (statements[k], statements[n]);
                    statements[n].AssertiveStatement =statements[n].AssertiveStatement.
                        Replace("{name}", name);
                }
                return statements;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return await Task.FromResult(new List<Statement>());
            }
        }

        public async Task<FinalResultVM?> SaveResponses(List<UserResponseVM> Responses, ReciprocityLevel level)
        {
            try
            {
                List<Response> data = [];
                int id = Convert.ToInt32(_userSession.GetUserId());
                int PersonId =  await _personDetailsRepository.GetPersonbyUserIdAsync(id);
                InteractionFrequency frequency = _personDetailsRepository.GetInteractionFrequency(PersonId);
                if (Responses != null && Responses.Count > 0)
                {
                    foreach (var response in Responses)
                    {
                        string category = _personDetailsRepository.GetCategoryByStatement(response.StatementId);
                        response.Category = category;
                        data.Add(new Response
                        {
                            PersonDetailsId = PersonId,
                            StatementId = response.StatementId,
                            Intensity = response.Intensity,
                        });
                    }
                    if(await _personDetailsRepository.SaveUserResponsesAsync(data))
                    {
                        Dictionary<string, int> statementScores = _personDetailsRepository.LoadStatementScores();
                        int YearsKnown = _personDetailsRepository.GetYearsKnownbyPersonId(PersonId);
                        FinalResultVM result = BESEngineV6.InitiateBES(Responses, level, frequency, YearsKnown, statementScores);
                        _personDetailsRepository.saveFinalResult(result, PersonId);
                        LoadResultPage(result, PersonId);
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
            return null;
        }
        private FinalResultVM? LoadResultPage(FinalResultVM result, int PersonId)
        {
            try
            {
                if(result != null && PersonId > 0)
                {
                    if(result.ResultCategory != FinalResultCategory.Neutral)
                    {
                        int ResultId = Convert.ToInt32(result.ResultCategory);
                        string message = _personDetailsRepository.getResultMessagebyId(ResultId);
                        var (UserName, PersonName, gender) = _personDetailsRepository.GetDataByPersonId(PersonId);
                        string pronoun = gender == Gender.male  ? "him" : "her";
                        if(!String.IsNullOrEmpty(PersonName) && 
                            !String.IsNullOrEmpty(UserName))
                        {
                            result.Message = message
                                .Replace("{user}", UserName)
                                .Replace("{name}", PersonName)
                                .Replace("{pronoun}", pronoun);
                        }
                        result.ImageURI = GetCategoryImage(result.ResultCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return result;
        }

        private static string GetCategoryImage(FinalResultCategory category)
        {
            return category switch
            {
                FinalResultCategory.Core => "/images/blueberry.png",
                FinalResultCategory.InnerCircle => "/images/blackberry.png",
                FinalResultCategory.Allies => "/images/whiteberry.png",
                FinalResultCategory.OuterCircle => "/images/greenberry.png",
                FinalResultCategory.QuarantineZone => "/images/yellowberry.png",
                FinalResultCategory.ExclusionZone => "/images/redberry.png",
                _ => string.Empty
            };
        }
    }
}
