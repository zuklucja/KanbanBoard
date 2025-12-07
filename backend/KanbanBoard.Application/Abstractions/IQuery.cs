namespace KanbanBoard.Application.Abstractions;

public interface IQuery<TResult>;

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    public Task<TResult> Handle(TQuery query);
}