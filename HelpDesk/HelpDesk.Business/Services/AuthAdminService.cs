using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.Business.Interfaces;
using HelpDesk.Data.Interfaces;
using HelpDesk.Domain.Entities;
using HelpDesk.Shared.Dtos;

namespace HelpDesk.Business.Services
{
    public class AuthAdminService : IAuthAdminService
    {
        private readonly IMapper _mapper;
        private readonly IAuthAdminRepository _authAdminRepository;
        public AuthAdminService(IMapper mapper,IAuthAdminRepository authAdminRepository)
        {
            _mapper = mapper;
            _authAdminRepository = authAdminRepository;
        }

        // Implement methods for authentication and authorization of admin users
        public async Task<ServiceResponse> RegisterAsync(RegisterDto registerDto)
        {
            var admin = _mapper.Map<ApplicationUser>(registerDto);

            var result = await _authAdminRepository.RegisterAdminAsync(admin, registerDto.PassWord);
            if (result.Succeeded)
            {
                return ServiceResponse.Ok();
            }

            var errors = result.Errors.Select(e => e.Description);
            return ServiceResponse.Fail(errors);

        }

        public async Task<ServiceResponse> LoginAsync(LoginDto loginDto)
        {
            var admin = _mapper.Map<ApplicationUser>(loginDto);

            var result = await _authAdminRepository.LoginAdminAsync(admin, loginDto.PassWord);
            if (result.Succeeded)
            {
                return ServiceResponse.Ok();
            }

            var errors = result.Errors.Select(e => e.Description);
            return ServiceResponse.Fail(errors);
        }
    }
}
