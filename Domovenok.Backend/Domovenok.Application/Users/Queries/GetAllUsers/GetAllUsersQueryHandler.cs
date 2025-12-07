using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domovenok.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UsersListVm>
    {
        private readonly IDomovenokDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IDomovenokDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UsersListVm> Handle(GetAllUsersQuery request,
       CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UsersListVm { Users = users };
        }

    }
}
