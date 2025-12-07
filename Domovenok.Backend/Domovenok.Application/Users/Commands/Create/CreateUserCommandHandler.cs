using Domovenok.Domain.Entities;
using Domovenok.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IDomovenokDbContext _dbContext;
        //_passwordHasher

        public CreateUserCommandHandler(IDomovenokDbContext dbContext) =>
           _dbContext = dbContext;
        //_passwordHasher


        public async Task<Guid> Handle(CreateUserCommand request,
           CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                PasswordHash = request.Password, //!!!ДОБАВИТЬ ХЭШИРОВАНИЕ
                Role = request.Role,
                Name = request.NickName,
                CreatedAt = DateTime.UtcNow,
                AvatarUrl = "/static/avatars/default.png", //!!!ДОБАВИТЬ СТ. ФОТО
                UserPreferences = new UserPreferences
                {
                     Theme = ThemeType.Light,
                     Language = LanguageType.Russia,
                     NotificationsEnabled = false,
                     EmailNotifications = false,
                     PushNotifications = false,
                     ReminderDaysDefault = 1
                }

            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
