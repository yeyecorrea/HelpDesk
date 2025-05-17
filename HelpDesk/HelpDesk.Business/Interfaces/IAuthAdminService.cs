using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Dtos;

namespace HelpDesk.Business.Interfaces
{
    public interface IAuthAdminService
    {
        Task<ServiceResponse> LoginAsync(LoginDto loginDto);
        Task<ServiceResponse> RegisterAsync(RegisterDto registerDto);
    }
}
