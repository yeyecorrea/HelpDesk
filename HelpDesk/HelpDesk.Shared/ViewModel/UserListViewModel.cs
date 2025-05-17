using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Shared.ViewModel
{
    public class UserListViewModel
    {
        public List<UserViewModel> Users { get; set; }

        public string Message { get; set; }
    }
}
