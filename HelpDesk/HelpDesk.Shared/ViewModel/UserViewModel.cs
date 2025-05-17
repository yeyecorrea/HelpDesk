using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Shared.ViewModel
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; } = new();

    }
}
