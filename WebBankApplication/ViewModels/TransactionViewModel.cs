namespace WebBankApplication.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string? Operation { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }


      
    }
}
