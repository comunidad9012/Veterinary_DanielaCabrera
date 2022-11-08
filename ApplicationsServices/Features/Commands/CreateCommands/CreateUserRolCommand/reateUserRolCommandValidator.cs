//Validamos los datos ingresados. Aquí podemos ver los requisitos para el dato sea aceptado
using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateUserRolCommand
{
    public class CreateUserRolCommandValidator : AbstractValidator<CreateUserRolCommand>
    {
        public CreateUserRolCommandValidator()
        {
            RuleFor(x => x.rol)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            
        }
    }
}
