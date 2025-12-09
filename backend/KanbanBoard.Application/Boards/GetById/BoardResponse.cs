namespace KanbanBoard.Application.Boards.GetById;

public class BoardResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required List<ColumnResponse> Columns { get; set; }
}

public class ColumnResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required List<CardResponse> Cards { get; set; }
    public required int Position { get; set; }
}

public class CardResponse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required int Position { get; set; }
}