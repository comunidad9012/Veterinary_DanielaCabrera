//Deben de existir datos YA creados en nuestra base de datos para que estos sean borrados exitosamente.
using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeletePetTypeCommand
{
    public class DeletePetTypeCommandValidator : AbstractValidator<DeletePetTypeCommand>
    {
        public DeletePetTypeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
