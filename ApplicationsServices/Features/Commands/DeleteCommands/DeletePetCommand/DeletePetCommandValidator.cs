//Deben de existir datos YA creados en nuestra base de datos para que estos sean borrados exitosamente.
using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeletePetCommand
{
    public class DeletePetCommandValidator : AbstractValidator<DeletePetCommand>
    {
        public DeletePetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
