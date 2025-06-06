using FluentValidation;
using LLMStudio.Data.Models;

namespace LLMStudio.Validators;

public class ModelTypeValidator:AbstractValidator<ModelType>
{
    public ModelTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorMessages.ModelTypeNameNotEmpty);
    }
}