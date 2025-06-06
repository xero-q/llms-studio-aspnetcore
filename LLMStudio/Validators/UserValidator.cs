using System.Data;
using FluentValidation;
using LLMStudio.Data.Models;

namespace LLMStudio.Validators;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x=>x.Username).NotEmpty().WithMessage(ErrorMessages.UsernameNotEmpty);

        RuleFor(x => x.Password).NotEmpty().WithMessage(ErrorMessages.PasswordNotEmpty);
    }
}