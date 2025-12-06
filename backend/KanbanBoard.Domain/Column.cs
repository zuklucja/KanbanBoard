namespace KanbanBoard.Domain;

public sealed class Column
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Position { get; set; }
    
    public required Board Board { get; set; }
    public required List<Card> Cards { get; set; }
}