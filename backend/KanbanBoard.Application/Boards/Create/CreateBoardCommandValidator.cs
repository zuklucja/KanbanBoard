using FluentValidation;

namespace KanbanBoard.Application.Boards.Create;

public class CreateBoardCommandValidator : AbstractValidator<CreateBoardCommand>
{
    public CreateBoardCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().MaximumLength(128);
    }
}