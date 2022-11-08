using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateVisitDetailCommand
{
    public class CreateVisitDetailCommandValidator : AbstractValidator<CreateVisitDetailCommand>
    {
        public CreateVisitDetailCommandValidator()
        {
            RuleFor(x => x.visitId)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                 .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.procedureId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.price)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

        }
    }
}
