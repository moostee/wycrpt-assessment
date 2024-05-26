using MediatR;

namespace TransactionService.Application.Contracts.Commands;

public interface ICommand<out TResult> : IRequest<TResult>
{
    Guid Id { get; }
}

public interface ICommand : IRequest<Unit>
{
    Guid Id { get; }
}
