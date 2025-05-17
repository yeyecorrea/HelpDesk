using System.Threading.Tasks;
using HelpDesk.Data.DataContext;
using HelpDesk.Domain.Entities;
using HelpDesk.Shared.Dtos;
using HelpDesk.Shared.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace HelpDesk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<IActionResult> ListUser( string message)
        {
            var users = await _context.Users
            .GroupJoin(
                _context.UserRoles,
                u => u.Id,
                ur => ur.UserId,
                (u, userRoles) => new { u, userRoles }
            )
            .Select(x => new
            {
                x.u.Email,
                x.u.UserName,
                Roles = from ur in x.userRoles
                        join r in _context.Roles on ur.RoleId equals r.Id
                        select r.Name
            })
            .Select(x => new UserViewModel
            {
                Email = x.Email,
                UserName = x.UserName,
                Roles = x.Roles.ToList()
            })
            .ToListAsync();

            var model = new UserListViewModel();
            model.Users = users;
            model.Message = message;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAdmin(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(user, Roles.Admin);
            return RedirectToAction("ListUser", "User");
        }

        [HttpPost]
        public async Task<IActionResult> MakeEncargado(string searchString)
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdmin(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.RemoveFromRoleAsync(user, Roles.Admin);
            return RedirectToAction("ListUser","User");
        }

    }
}
