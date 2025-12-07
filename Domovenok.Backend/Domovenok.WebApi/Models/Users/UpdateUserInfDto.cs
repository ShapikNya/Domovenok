using AutoMapper;
using Domovenok.Application.Common.Mappings;
using Domovenok.Application.Users.Commands.Create;
using Domovenok.Application.Users.Commands.Update;
using Domovenok.Domain.Enums;

namespace Domovenok.WebApi.Models.Users
{
    public class UpdateUserInfDto : IMapWith<UpdateUserInfCommand>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string AvatarUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserInfDto, UpdateUserInfCommand>();
        }
    }
}
