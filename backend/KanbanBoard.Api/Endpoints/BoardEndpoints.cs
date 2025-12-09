using FluentValidation;
using KanbanBoard.Application.Abstractions;
using KanbanBoard.Application.Boards.Create;
using KanbanBoard.Application.Boards.Delete;
using KanbanBoard.Application.Boards.Get;
using KanbanBoard.Application.Boards.GetById;
using KanbanBoard.Application.Boards.Update;
using Microsoft.AspNetCore.Http.HttpResults;
using BoardResponse = KanbanBoard.Application.Boards.GetById.BoardResponse;

namespace KanbanBoard.Api.Endpoints;

public static class BoardEndpoints
{
    public static void MapBoardEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var boards = endpoints.MapGroup("/boards")
            .WithTags("Boards");

        boards.MapGet("/", GetBoards);
        boards.MapGet("/{id:int}", GetBoardById);

        boards.MapPost("/", CreateBoard)
            .ProducesValidationProblem();
        boards.MapPut("/{id:int}", UpdateBoard)
            .ProducesValidationProblem();
        boards.MapDelete("/{id:int}", DeleteBoard);
    }

    private static async Task<Ok<GetBoardsResponse>> GetBoards(IQueryHandler<GetBoardsQuery, GetBoardsResponse> handler)
    {
        var boards = await handler.Handle(new GetBoardsQuery());
        
        return TypedResults.Ok(boards);
    }

    private static async Task<Results<Ok<BoardResponse>, NotFound>> GetBoardById(
        IQueryHandler<GetBoardByIdQuery, BoardResponse?> handler,
        int id)
    {
        var board = await handler.Handle(new GetBoardByIdQuery(id));
        if (board == null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(board);
    }

    private static async Task<Results<Ok<int>, BadRequest>> CreateBoard(
        ICommandHandler<CreateBoardCommand, int> handler,
        IValidator<CreateBoardCommand> validator,
        CreateBoardCommand command)
    {
        await validator.ValidateAndThrowAsync(command);

        var id = await handler.Handle(command);
        if (id <= 0)
            return TypedResults.BadRequest();
        
        return TypedResults.Ok(id);
    }

    private static async Task<Results<Ok, NotFound, BadRequest>> UpdateBoard(
        ICommandHandler<UpdateBoardCommand, bool> handler,
        IValidator<UpdateBoardCommand> validator,
        int id,
        UpdateBoardCommand command)
    {
        await validator.ValidateAndThrowAsync(command);

        if (id != command.Id)
            return TypedResults.BadRequest();

        var result = await handler.Handle(command);
        if (!result)
            return TypedResults.NotFound();
        
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> DeleteBoard(ICommandHandler<DeleteBoardCommand, bool> handler,
        int id)
    {
        var result = await handler.Handle(new DeleteBoardCommand(id));
        if (!result)
            return TypedResults.NotFound();
        
        return TypedResults.Ok();
    }
}