using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdateProcedureCommand
{
    public class UpdateProcedureCommandValidator : AbstractValidator<UpdateProcedureCommand>
    {
        public UpdateProcedureCommandValidator()
        {
            RuleFor(x => x.procedure)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                 .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
       
        }
    }
}
