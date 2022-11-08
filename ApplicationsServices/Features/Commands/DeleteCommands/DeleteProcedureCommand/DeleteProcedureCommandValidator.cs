using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeleteProcedureCommand
{
    public class DeleteProcedureCommandValidator : AbstractValidator<DeleteProcedureCommand>
    {
        public DeleteProcedureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
