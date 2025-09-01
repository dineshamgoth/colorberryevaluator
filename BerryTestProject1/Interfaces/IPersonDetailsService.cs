using Azure;
using BerryTestProject1.Berry.Core;
using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BerryTestProject1.Interfaces
{
    public interface IPersonDetailsService
    {
        Task AddPersonAsync(PersonDetailsVM data);
        Task<List<Statement>> GetRandomStatementsAsync(string name);
        Task<FinalResultVM?> SaveResponses(List<UserResponseVM> Responses, ReciprocityLevel level);
    }
}
