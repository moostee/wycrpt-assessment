using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionService.Domain
{
    [Table("TransactionHistory", Schema = "dbo")]
    public class TransactionHistory : BaseEntity<Guid>, IEquatable<TransactionHistory>
    {
        [MaxLength(200)]
        public string BlockNumber { get; private set; }
        [MaxLength(200)]
        public string SenderAddress { get; private set; }
        [MaxLength(200)]
        public string ReceiverAddress { get; private set; }
        [MaxLength(50)]
        public decimal Amount { get; private set; }
        [MaxLength(10)]
        public string Currency { get; private set; }
        [MaxLength(200)]
        public string TransactionHash { get; private set; }
        [MaxLength(50)]
        public string Network { get; private set; }

        public TransactionHistory() { }

        private TransactionHistory(string transactionHash, string network, string blockNumber, string senderAddress, string receiverAddress, decimal amount, string currency)
        {
            TransactionHash = transactionHash;
            Network = network;
            BlockNumber = blockNumber;
            SenderAddress = senderAddress;
            ReceiverAddress = receiverAddress;
            Amount = amount;
            Currency = currency;
        }

        public static TransactionHistory Create(string transactionHash, string network, string blockNumber, string senderAddress, string receiverAddress, decimal amount, string currency)
            => new(transactionHash, network, blockNumber, senderAddress, receiverAddress, amount, currency);

        public bool Equals(TransactionHistory other)
        {
            return other.Amount == Amount
                    && other.Currency == Currency
                    && other.TransactionHash == TransactionHash
                    && other.Network == Network
                    && other.BlockNumber == BlockNumber
                    && other.SenderAddress == SenderAddress
                    && other.ReceiverAddress == ReceiverAddress;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TransactionHistory);
        }

    }
}