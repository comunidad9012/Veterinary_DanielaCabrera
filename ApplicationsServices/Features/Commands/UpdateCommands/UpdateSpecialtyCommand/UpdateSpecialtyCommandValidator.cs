using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdateSpecialtyCommand
{
    public class UpdateSpecialtyCommandValidator : AbstractValidator<UpdateSpecialtyCommand>
    {
        public UpdateSpecialtyCommandValidator()
        {
            RuleFor(x => x.specialty)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                 .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

        }
    }
}
