using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeleteSpecialtyCommand
{
    public class DeleteSpecialtyCommandValidator : AbstractValidator<DeleteSpecialtyCommand>
    {
        public DeleteSpecialtyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
