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

/*public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, TaskListVm>
{
    private readonly ITasksDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTaskListQueryHandler(ITasksDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<TaskListVm> Handle(GetTaskListQuery request,
       CancellationToken cancellationToken)
    {
        var tasks = await _dbContext.Tasks
            *//*.Where(t => t.UserId == request.UserId)*//*
            .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new TaskListVm { Tasks = tasks };
    }

}
*/