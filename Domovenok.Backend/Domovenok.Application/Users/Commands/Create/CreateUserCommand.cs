using Domovenok.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RoleType Role { get; set; } = RoleType.User;

    }
}
