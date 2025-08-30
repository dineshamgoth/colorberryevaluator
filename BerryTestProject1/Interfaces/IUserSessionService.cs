using BerryTestProject1.ViewModels;

namespace BerryTestProject1.Interfaces
{
    public interface IUserSessionService
    {
        string? GetUserId();
        string? GetUsername();
        string? GetFullName();
        string? GetUserMail();
        void ClearSession();
    }
}
