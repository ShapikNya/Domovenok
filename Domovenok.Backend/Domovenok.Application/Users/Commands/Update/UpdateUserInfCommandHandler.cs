using Domovenok.Application.Common.Exceptions;
using Domovenok.Application.Users.Commands.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Commands.Update
{
    public class UpdateUserInfCommandHandler : IRequestHandler<UpdateUserInfCommand>
    {
        private readonly IDomovenokDbContext _dbContext;

        public UpdateUserInfCommandHandler(IDomovenokDbContext dbContext) =>
           _dbContext = dbContext;
        public async Task Handle(UpdateUserInfCommand request,
           CancellationToken cancellationToken)
        { 
            var user = await _dbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }
            user.Email = request.Email; user.Name= request.NickName; user.Phone = request.Phone; user.BirthDate = request.BirthDate; user.AvatarUrl = request.AvatarUrl;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
