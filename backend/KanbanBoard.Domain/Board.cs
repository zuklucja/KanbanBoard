namespace KanbanBoard.Domain;

public sealed class Board
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public required List<Column> Columns { get; set; }
}