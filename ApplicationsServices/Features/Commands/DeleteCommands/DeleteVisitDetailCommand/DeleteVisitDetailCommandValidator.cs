using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeleteVisitDetailCommand
{
    public class DeleteVisitDetailCommandValidator : AbstractValidator<DeleteVisitDetailCommand>
    {
        public DeleteVisitDetailCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
