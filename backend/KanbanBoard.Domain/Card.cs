namespace KanbanBoard.Domain;

public sealed class Card
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required int Position { get; set; }
    
    public required Column Column { get; set; }
}