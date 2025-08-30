using BerryTestProject1.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BerryTestProject1.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace BerryTestProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserSessionService _userSessionService;
        private readonly IRelationshipService _relationshipService;
        public HomeController(IUserSessionService userSessionService, IRelationshipService relationshipService)
        {
            _userSessionService = userSessionService;
            _relationshipService = relationshipService;
        }
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Name = _userSessionService.GetFullName();
            ViewBag.Email = _userSessionService.GetUserMail();
            ViewBag.ShowButton = true;
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            _userSessionService.ClearSession();
            await HttpContext.SignOutAsync("UserCookie");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "UserData");
        }
        [Authorize]
        public IActionResult Evaluate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Evaluate([FromForm] PersonDetailsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _relationshipService.AddPersonAsync(model);
                    RedirectToAction("Questions");
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }
    }
}
