using System.Linq.Expressions;

namespace TransactionService.Domain
{
    public interface ITransactionHistoryRepository
    {
        Task AddAsync(TransactionHistory transactionHistory);
        public Task<TransactionHistory> GetSingleAsync(Expression<Func<TransactionHistory, bool>> predicate);
        public Task<List<TransactionHistoryModel>> GetTransactionHistoryAsync(string blockNumber, string address, string currency);
    }
}