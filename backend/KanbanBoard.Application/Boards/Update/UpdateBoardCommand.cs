using KanbanBoard.Application.Abstractions;

namespace KanbanBoard.Application.Boards.Update;

public record UpdateBoardCommand(int Id, string Name) : ICommand<bool>;