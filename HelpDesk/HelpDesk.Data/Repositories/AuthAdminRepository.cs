using HelpDesk.Data.Interfaces;
using HelpDesk.Domain.Entities;
using HelpDesk.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HelpDesk.Data.Repositories
{
    public class AuthAdminRepository : IAuthAdminRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AuthAdminRepository> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthAdminRepository(UserManager<ApplicationUser> userManager, ILogger<AuthAdminRepository> logger, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
        }

        // Implement methods for authentication and authorization of admin users
        public async Task<IdentityResult> RegisterAdminAsync(ApplicationUser user, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return result;
                }

                var roleResult = await _userManager.AddToRoleAsync(user, Roles.Admin);
                if (!roleResult.Succeeded)
                {
                    return roleResult;
                }

                return IdentityResult.Success;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error inesperado al registrar usuario y asignar rol.");
                var error = new IdentityError { Description = "Error inesperado al registrar el usuario y asignar rol." };
                return IdentityResult.Failed(error);
            }
        }

        public async Task<IdentityResult> LoginAdminAsync(ApplicationUser user, string password)
        {
            try
            {
                var getUser = await _userManager.FindByNameAsync(user.UserName);
                if (getUser == null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Usuario no encontrado" });
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, password, lockoutOnFailure: true, isPersistent: false);
                if (!result.Succeeded)
                {
                   return IdentityResult.Failed(new IdentityError { Description = "Error al iniciar sesion, usuario o contraseña incorrectas" });
                }

                return IdentityResult.Success;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
