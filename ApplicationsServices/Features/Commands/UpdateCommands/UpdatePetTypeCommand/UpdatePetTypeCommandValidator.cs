using ApplicationsServices.Features.Commands.CreateCommands.CreatePetTypeCommand;
using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdatePetTypeCommand
{
    public class UpdatePetTypeCommandValidator : AbstractValidator<CreatePetTypeCommand>
    {
        public UpdatePetTypeCommandValidator()
        {
            RuleFor(x => x.type)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
          
        }
    }
}
