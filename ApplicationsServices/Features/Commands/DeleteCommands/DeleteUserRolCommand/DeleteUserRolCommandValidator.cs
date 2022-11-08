//Deben de existir datos YA creados en nuestra base de datos para que estos sean borrados exitosamente.
using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeleteUserRolCommand
{
    public class DeleteUserRolCommandValidator : AbstractValidator<DeleteUserRolCommand>
    {
        public DeleteUserRolCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
