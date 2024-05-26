using TransactionService.Application.Contracts.Queries;
using TransactionService.Domain;

namespace TransactionService.Application.UseCases.GetAddressTransactionHistory;

public record GetAddressTransactionHistoryQuery(string BlockNumber, string Address, string Currency) : QueryBase<ServiceResponse<List<TransactionHistoryModel>>>
{ }
