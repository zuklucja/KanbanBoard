using KanbanBoard.Application.Abstractions;

namespace KanbanBoard.Application.Boards.Delete;

public record DeleteBoardCommand(int BoardId) : ICommand<bool>;