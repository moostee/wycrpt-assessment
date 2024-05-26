using MediatR;

namespace TransactionService.Application.Contracts.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{ }

public abstract record QueryBase<TResult> : IQuery<TResult> { }