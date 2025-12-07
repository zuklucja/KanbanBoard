using KanbanBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Application.Abstractions;

public interface IKanbanDbContext
{
    DbSet<Board> Boards
    {
        get;
    }

    DbSet<Column> Columns
    {
        get;
    }

    DbSet<Card> Cards
    {
        get;
    }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}