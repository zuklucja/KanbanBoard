using KanbanBoard.Application.Abstractions;

namespace KanbanBoard.Application.Boards.Create;

public record CreateBoardCommand(string Name) : ICommand<int>;