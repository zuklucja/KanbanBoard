using KanbanBoard.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KanbanBoard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("KanbanDatabase");

        services.AddDbContext<KanbanDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IKanbanDbContext>(provider => provider.GetRequiredService<KanbanDbContext>());

        return services;
    }
}