using TransactionService.Domain;

namespace TransactionService.Application.UseCases.GetAddressTransactionHistory;

public sealed class GetAddressTransactionHistoryResult : ServiceResponse<List<TransactionHistoryModel>>
{ }