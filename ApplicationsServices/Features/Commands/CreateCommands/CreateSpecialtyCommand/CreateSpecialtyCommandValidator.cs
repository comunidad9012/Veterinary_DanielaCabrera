using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateSpecialtyCommand
{
    public class CreateSpecialtyCommandValidator : AbstractValidator<CreateSpecialtyCommand>
    {
        public CreateSpecialtyCommandValidator()
        {
            RuleFor(x => x.specialty)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }
    }
}
