﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Business.Interfaces
{
    public interface IRoleService
    {
        Task CreateRoleAsync(string roleName);
    }
}
