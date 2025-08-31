using BerryTestProject1.Interfaces;
using BerryTestProject1.Models;
using BerryTestProject1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BerryTestProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserSessionService _userSessionService;
        private readonly IPersonDetailsService _relationshipService;
        public HomeController(IUserSessionService userSessionService, IPersonDetailsService relationshipService)
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
        public IActionResult PersonForm()
        {
            return View();
        }
        [Route("PersonForm")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PersonForm([FromForm] PersonDetailsVM model)
        {
            try
            {
                if (!String.IsNullOrEmpty(model.PersonName) && model.YearsKnown > 0)
                {
                    await _relationshipService.AddPersonAsync(model);
                    return RedirectToAction("Statements", new {name = model.PersonName});
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }
        [Route("Statements")]
        [Authorize]
        public IActionResult Statements(string name)
        {
            List<Statement> statements = [];
            try
            {
               statements = _relationshipService.GetRandomStatementsAsync(name).Result; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View(statements);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EvaluationResult([FromForm] List<UserResponseVM> Responses)
        {
            try
            {
                _relationshipService.SaveResponses(Responses);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }
    }
}
