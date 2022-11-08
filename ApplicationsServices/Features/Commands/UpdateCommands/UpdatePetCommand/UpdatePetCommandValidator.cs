using ApplicationsServices.Features.Commands.CreateCommands.CreatePetCommand;
using FluentValidation;


namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdatePetCommand
{
    public class UpdatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public UpdatePetCommandValidator()
        {
            RuleFor(x => x.petName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.typeId)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.clientId)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
        }
    }

}
