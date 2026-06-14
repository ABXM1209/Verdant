namespace Application.Common.Interfaces.Auth;

public interface ICommandHandler<in TCommand, TResponseResult>
{
    Task<TResponseResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}