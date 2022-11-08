//Deben de existir datos YA creados en nuestra base de datos para que estos sean borrados exitosamente.
using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeleteVetCommand
{
    public class DeleteVetCommandValidator : AbstractValidator<DeleteVetCommand>
    {
        public DeleteVetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
