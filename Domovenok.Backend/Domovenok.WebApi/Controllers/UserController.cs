using AutoMapper;
using Domovenok.Application.Users.Commands.Create;
using Domovenok.Application.Users.Commands.Delete;
using Domovenok.Application.Users.Commands.Update;
using Domovenok.Application.Users.Queries.GetAllUsers;
using Domovenok.Application.Users.Queries.GetUserById;
using Domovenok.WebApi.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Domovenok.WebApi.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<UsersListVm>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserVm>> Get(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
      
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto dto)
        {
            var command = _mapper.Map<CreateUserCommand>(dto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserInfDto dto)
        {
            var command = _mapper.Map<UpdateUserInfCommand>(dto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent(); 
        }

        /*
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            command.UserId = UserId;
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }*/







    }
}
