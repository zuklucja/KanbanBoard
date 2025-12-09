using FluentValidation;
using KanbanBoard.Application.Abstractions;
using KanbanBoard.Application.Boards.Create;
using KanbanBoard.Application.Boards.Delete;
using KanbanBoard.Application.Boards.Get;
using KanbanBoard.Application.Boards.GetById;
using KanbanBoard.Application.Boards.Update;
using Microsoft.Extensions.DependencyInjection;
using BoardResponse = KanbanBoard.Application.Boards.GetById.BoardResponse;

namespace KanbanBoard.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IQueryHandler<GetBoardsQuery, GetBoardsResponse>, GetBoardsQueryHandler>();
        services.AddTransient<IQueryHandler<GetBoardByIdQuery, BoardResponse?>, GetBoardByIdQueryHandler>();
        services.AddTransient<ICommandHandler<CreateBoardCommand, int>, CreateBoardCommandHandler>();
        services.AddTransient<ICommandHandler<UpdateBoardCommand, bool>, UpdateBoardCommandHandler>();
        services.AddTransient<ICommandHandler<DeleteBoardCommand, bool>, DeleteBoardCommandHandler>();

        services.AddValidatorsFromAssemblyContaining<CreateBoardCommandValidator>();

        return services;
    }
}