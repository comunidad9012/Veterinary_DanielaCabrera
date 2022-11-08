//Validamos los datos ingresados. Aquí podemos ver los requisitos para el dato sea aceptado
using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreatePetCommand
{
    public class CreatePetCommandValidator :AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(x => x.petName)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.clientId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.typeId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
        }
    }
}
