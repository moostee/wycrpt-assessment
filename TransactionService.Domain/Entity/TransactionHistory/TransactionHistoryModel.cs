namespace TransactionService.Domain
{
    public class TransactionHistoryModel
    {
        public string BlockNumber { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionHash { get; set; }
        public string Network { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}