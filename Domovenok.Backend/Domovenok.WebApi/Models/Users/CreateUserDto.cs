using AutoMapper;
using Domovenok.Application.Common.Mappings;
using Domovenok.Application.Users.Commands.Create;
using System.ComponentModel.DataAnnotations;

namespace Domovenok.WebApi.Models.Users
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        [Required]
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>();
        }

    }
}
