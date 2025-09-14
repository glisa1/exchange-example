namespace Exchange_Example_Api.Utils.Request;

public interface ICommandRequestHandler<TCommand, TResult> where TCommand : Command
{
    Task<TResult> Handle(TCommand command, CancellationToken cancellationToken = default);
}
