namespace KanbanBoard.Application.Boards.Get;

public class GetBoardsResponse
{
    public required List<BoardResponse> Boards { get; set; }
}

public class BoardResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}