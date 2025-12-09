using KanbanBoard.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Application.Boards.Delete;

public class DeleteBoardCommandHandler(IKanbanDbContext context) : ICommandHandler<DeleteBoardCommand, bool>
{
    public async Task<bool> Handle(DeleteBoardCommand command)
    {
        var board = await context.Boards
            .Where(board => board.Id == command.BoardId)
            .FirstOrDefaultAsync();
        if (board == null)
            return false;

        context.Boards.Remove(board);
        await context.SaveChangesAsync();
        return true;
    }
}