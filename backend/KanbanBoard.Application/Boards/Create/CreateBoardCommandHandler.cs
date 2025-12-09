using KanbanBoard.Application.Abstractions;
using KanbanBoard.Domain;

namespace KanbanBoard.Application.Boards.Create;

public class CreateBoardCommandHandler(IKanbanDbContext context) : ICommandHandler<CreateBoardCommand, int>
{
    public async Task<int> Handle(CreateBoardCommand command)
    {
        var board = new Board
        {
            Name = command.Name,
            Columns = []
        };
        context.Boards.Add(board);
        await context.SaveChangesAsync();

        return board.Id;
    }
}