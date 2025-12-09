using KanbanBoard.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Application.Boards.Update;

public class UpdateBoardCommandHandler(IKanbanDbContext context) : ICommandHandler<UpdateBoardCommand, bool>
{
    public async Task<bool> Handle(UpdateBoardCommand command)
    {
        var board = await context.Boards
            .Where(board => board.Id == command.Id)
            .FirstOrDefaultAsync();
        if (board == null)
            return false;

        board.Name = command.Name;

        await context.SaveChangesAsync();
        return true;
    }
}