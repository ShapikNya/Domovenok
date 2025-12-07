using AutoMapper;
using Domovenok.Application.Common.Mappings;
using Domovenok.Application.Users.Queries.GetUserById;
using Domovenok.Domain.Entities;
using Domovenok.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Queries.GetAllUsers
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>();

        }
    }

}
