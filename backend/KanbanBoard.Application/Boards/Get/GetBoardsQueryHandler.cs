using KanbanBoard.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Application.Boards.Get;

public class GetBoardsQueryHandler(IKanbanDbContext context) : IQueryHandler<GetBoardsQuery, GetBoardsResponse>
{
    public async Task<GetBoardsResponse> Handle(GetBoardsQuery query)
    {
        var boards = await context.Boards
            .OrderBy(b => b.Id)
            .Select(b => new BoardResponse
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();

        return new GetBoardsResponse
        {
            Boards = boards
        };
    }
}