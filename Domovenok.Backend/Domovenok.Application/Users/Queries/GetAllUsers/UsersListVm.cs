using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Queries.GetAllUsers
{
    public class UsersListVm
    {
        public IList<UserLookupDto> Users { get; set; }
    }
}
