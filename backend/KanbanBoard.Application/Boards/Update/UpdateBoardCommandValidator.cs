using FluentValidation;

namespace KanbanBoard.Application.Boards.Update;

public class UpdateBoardCommandValidator : AbstractValidator<UpdateBoardCommand>
{
    public UpdateBoardCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(command => command.Name).NotEmpty().MaximumLength(128);
    }
}