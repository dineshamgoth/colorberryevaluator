using BerryTestProject1.Interfaces;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
namespace BerryTestProject1.Services
{
    public class UserSessionService(IHttpContextAccessor httpContextAccessor) : IUserSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public string? GetUsername()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst("Username")?.Value;
        }

        public string? GetFullName()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        }

        public string? GetUserMail()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
        }

        public void ClearSession()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                context.SignOutAsync("UserCookie").Wait();
            }
        }

    }
}
