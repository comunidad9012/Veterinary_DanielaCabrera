//Validamos los datos ingresados. Aquí podemos ver los requisitos para el dato sea aceptado
//No llegamos a terminar esta entidad :(
using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateVetCommand
{
    public class CreateVetCommandValidator : AbstractValidator<CreateVetCommand>
    {
        public CreateVetCommandValidator()
        {
            RuleFor(x => x.vetName)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
               .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.vetSurname)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.vetAdress)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.vetPhoneNum)
                .Matches(@"^[0-9]+").WithMessage("Teléfono solo debe contener números.")
                .MaximumLength(14).WithMessage("Teléfono no debe exeder de {MaxLength} caracteres.")
                .MinimumLength(6).WithMessage("Teléfono no debe contener menos de {MaxLength} caracteres.");
            RuleFor(x => x.vetIdn)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

        }
    }
}
