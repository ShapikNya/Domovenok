using AutoMapper;
using Domovenok.Application.Common.Exceptions;
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

        /// <summary>
        /// Returns a list of all users.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/users
        /// </remarks>
        /// <returns>List of users</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsersListVm))]
        public async Task<ActionResult<UsersListVm>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Returns a single user by ID.
        /// </summary>
        /// Sample request:
        /// GET /api/users/{id}
        /// {
        ///     "Id": "41d9bd55-66fb-43c4-93a2-68fa37256e33",
        /// }
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserVm))]
        public async Task<ActionResult<UserVm>> Get(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /api/users
        /// {
        ///     "NickName": "GucciPlayer2004",
        ///     "Email": "bubilda@gmail.ru",
        ///     "Password": "qwerty123"
        /// }
        /// </remarks>
        /// <param name="dto">DTO containing the new user's data</param>
        /// <returns>The ID of the created user</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto dto)
        {
            var command = _mapper.Map<CreateUserCommand>(dto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/users/{id}
        /// {
        ///     "NickName": "user",
        ///     "Email": "user@gmail.ru",
        ///     "Phone": "+123456789",
        ///     "BirthDate": "2004-04-15T00:00:00",
        ///     "AvatarUrl": "/avatars/gucci.png"
        /// }
        /// </remarks>
        /// <param name="id">The ID of the user to update</param>
        /// <param name="dto">DTO containing updated user data</param>
        /// <returns>No content if successful</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Update([FromBody] UpdateUserInfDto dto, Guid id)
        {
            var command = _mapper.Map<UpdateUserInfCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }


        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/users/{id}
        /// {
        ///     "Id": "41d9bd55-66fb-43c4-93a2-68fa37256e33",
        /// }
        /// <param name="id">User ID</param>
        /// </remarks>
        /// <returns>No content on success</returns>
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
    }
}
