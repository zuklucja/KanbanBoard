using KanbanBoard.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Application.Boards.GetById;

public class GetBoardByIdQueryHandler(IKanbanDbContext context) : IQueryHandler<GetBoardByIdQuery, BoardResponse?>
{
    public async Task<BoardResponse?> Handle(GetBoardByIdQuery query)
    {
        var board = await context.Boards
            .Where(b => b.Id == query.BoardId)
            .Include(b => b.Columns)
            .ThenInclude(col => col.Cards)
            .SingleOrDefaultAsync();

        if (board == null)
            return null;

        return new BoardResponse
        {
            Id = board.Id,
            Name = board.Name,
            Columns = board.Columns.ConvertAll(col => new ColumnResponse
            {
                Id = col.Id,
                Name = col.Name,
                Position = col.Position,
                Cards = col.Cards.ConvertAll(card => new CardResponse
                {
                    Id = card.Id,
                    Title = card.Title,
                    Description = card.Description,
                    Position = card.Position
                })
            })
        };
    }
}