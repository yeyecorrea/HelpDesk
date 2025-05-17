using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.Data.Interfaces
{
    public interface IAuthAdminRepository
    {
        Task<IdentityResult> LoginAdminAsync(ApplicationUser user, string password);
        Task<IdentityResult> RegisterAdminAsync(ApplicationUser user, string password);
    }
}
