using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KanbanBoard.Infrastructure;

public class KanbanDbContextFactory : IDesignTimeDbContextFactory<KanbanDbContext>
{
    public KanbanDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<KanbanDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("KANBAN_DB_CONNECTION");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException(
                "Connection string not set. Please define environment variable 'KANBAN_DB_CONNECTION'.");

        optionsBuilder.UseNpgsql(connectionString);

        return new KanbanDbContext(optionsBuilder.Options);
    }
}