namespace KanbanBoard.Application.Abstractions;

public interface ICommand<TResult>;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    public Task<TResult> Handle(TCommand command);
}