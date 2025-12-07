using AutoMapper;
using Domovenok.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserVm>
    {
        private readonly IDomovenokDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IDomovenokDbContext dbContext,
         IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);


        public async Task<UserVm> Handle(GetUserByIdQuery request,
        CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null) { throw new NotFoundException(nameof(user), request.Id); }

            return _mapper.Map<UserVm>(user);
        }
    }
}