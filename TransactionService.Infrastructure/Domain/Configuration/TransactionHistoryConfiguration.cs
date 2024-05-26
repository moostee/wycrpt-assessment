using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionService.Domain;

namespace TransactionService.Infrastructure.Domain.Configuration
{
    internal class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(m => new { m.SenderAddress, m.ReceiverAddress, m.Currency, m.Amount, m.BlockNumber });
            builder.ToTable(nameof(TransactionHistory), "dbo");
        }
    }
}