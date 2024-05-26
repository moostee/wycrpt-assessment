using TransactionService.Application.Contracts.Handlers;
using TransactionService.Domain;

namespace TransactionService.Application.UseCases.GetAddressTransactionHistory;

internal sealed class GetAddressTransactionHistoryQueryHandler(ITransactionHistoryRepository transactionHistoryRepository)
: IQueryHandler<GetAddressTransactionHistoryQuery, ServiceResponse<List<TransactionHistoryModel>>>
{
    private readonly ITransactionHistoryRepository _transactionHistoryRepository = transactionHistoryRepository;
    public async Task<ServiceResponse<List<TransactionHistoryModel>>> Handle(GetAddressTransactionHistoryQuery request, CancellationToken cancellationToken)
    {

        var result = await _transactionHistoryRepository.GetTransactionHistoryAsync(request.BlockNumber, request.Address, request.Currency);

        return GetAddressTransactionHistoryResult.Success(result);
    }

}
