using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeleteVisitCommand
{
    public class DeleteVisitCommandValidator : AbstractValidator<DeleteVisitCommand>
    {
        public DeleteVisitCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
