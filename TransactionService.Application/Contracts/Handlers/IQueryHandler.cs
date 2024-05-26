using MediatR;
using TransactionService.Application.Contracts.Queries;

namespace TransactionService.Application.Contracts.Handlers;

public interface IQueryHandler<in TQuery, TResult> :
       IRequestHandler<TQuery, TResult>
       where TQuery : IQuery<TResult>
{
}