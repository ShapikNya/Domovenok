using Domovenok.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Users.Commands.Update
{
    public class UpdateUserInfCommandValidator : AbstractValidator<UpdateUserInfCommand>
    {
        public UpdateUserInfCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Идентификатор пользователя обязателен")
                .NotEqual(Guid.Empty).WithMessage("Идентификатор пользователя не может быть пустым");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен")
                .MaximumLength(150).WithMessage("Email не должен превышать 150 символов")
                .EmailAddress().WithMessage("Некорректный формат email")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Email должен содержать '@' и домен");

            RuleFor(x => x.NickName)
                .NotEmpty().WithMessage("Имя обязательно")
                .MinimumLength(2).WithMessage("Имя должно содержать минимум 2 символа")
                .MaximumLength(30).WithMessage("Имя не должно превышать 30 символов")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s\-']+$")
                .WithMessage("Имя может содержать только буквы, пробелы, дефисы и апострофы");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Телефон обязателен")
                .MaximumLength(20).WithMessage("Телефон не должен превышать 20 символов")
                .Matches(@"^[\+\d\s\-\(\)]+$")
                .WithMessage("Некорректный формат телефона. Допустимы цифры, +, -, пробелы, скобки")
                .Must(CustomValidators.BeValidPhoneNumber).WithMessage("Некорректный номер телефона");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Дата рождения обязательна")
                .LessThan(DateTime.Today).WithMessage("Дата рождения не может быть в будущем")
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-120))
                .WithMessage("Возраст не может превышать 120 лет")
                .Must(CustomValidators.BeValidAge).WithMessage("Пользователь должен быть старше 12 лет");
        }
    }
}