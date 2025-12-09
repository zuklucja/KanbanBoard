using KanbanBoard.Application.Abstractions;

namespace KanbanBoard.Application.Boards.GetById;

public record GetBoardByIdQuery(int BoardId) : IQuery<BoardResponse?>;