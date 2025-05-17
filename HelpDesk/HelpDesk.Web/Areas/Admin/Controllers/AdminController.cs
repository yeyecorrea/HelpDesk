using HelpDesk.Business.Interfaces;
using HelpDesk.Shared.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAuthAdminService _authAdminService;
        public AdminController(IAuthAdminService authAdminService)
        {
            _authAdminService = authAdminService;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _authAdminService.RegisterAsync(model);

            if (response.Success)
            {
                return RedirectToAction("Login", "Admin");
            }

            foreach (var error in response.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _authAdminService.LoginAsync(model);
            if (response.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in response.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            // Implement logout logic here
            return RedirectToAction("Login", "Admin");
        }
    }
}
