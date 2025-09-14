namespace Exchange_Example_Api.Utils.Request;

public interface IQueryRequestHandler<TQuery, TResult> where TQuery : Query
{
    Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default);
}
