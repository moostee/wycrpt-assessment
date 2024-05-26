using System.Linq.Expressions;
using TransactionService.Domain;
using Microsoft.EntityFrameworkCore;
using TransactionService.Infrastructure.DataAccess;
using Dapper;

namespace TransactionService.Infrastructure.Domain
{
    internal class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly TransactionServiceContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public TransactionHistoryRepository(TransactionServiceContext context, ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task AddAsync(TransactionHistory transactionHistory)
        {
            var existing = await GetSingleAsync(c => c.BlockNumber == transactionHistory.BlockNumber);
            if (existing is not null && existing.Equals(transactionHistory)) { return; }

            await _context.AddAsync(transactionHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionHistory> GetSingleAsync(Expression<Func<TransactionHistory, bool>> predicate)
            => await _context.TransactionHistory.FirstOrDefaultAsync(predicate);

        public async Task<List<TransactionHistoryModel>> GetTransactionHistoryAsync(string blockNumber, string address, string currency)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @$"SELECT BlockNumber,
                             SenderAddress,
                             ReceiverAddress,
                             Currency, 
                             Amount, 
                             TransactionHash, 
                             Network,
                             CreatedOn As TransactionDate FROM [dbo].[TransactionHistory] WHERE 
                        {nameof(TransactionHistory.BlockNumber)} = @BlockNumber
                        AND ({nameof(TransactionHistory.SenderAddress)} = @Address
                        OR {nameof(TransactionHistory.ReceiverAddress)} = @Address)
                        AND {nameof(TransactionHistory.Currency)} = @Currency";
            
            var result = await connection.QueryAsync<TransactionHistoryModel>(sql, new {
                BlockNumber = blockNumber,
                Address = address,
                Currency = currency
            });

            return result.AsList();
        }
    }

}