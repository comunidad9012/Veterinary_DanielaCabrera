using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateProcedureCommand
{
    public class CreateProcedureCommandValidator : AbstractValidator<CreateProcedureCommand>
    {
        public CreateProcedureCommandValidator()
        {
            RuleFor(x => x.procedure)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }
    }
}
