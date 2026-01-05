using Domovenok.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Commands.Update
{
    public class UpdateUserInfCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string AvatarUrl { get; set; }
    }
}
