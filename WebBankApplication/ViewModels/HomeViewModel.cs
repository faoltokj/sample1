using WebBankApplication.BankApplication;

namespace WebBankApplication.ViewModels
{
    public class HomeViewModel
    {
        public int TotalCustomers { get; set; }
        public int TotalAccounts { get; set; }
        public decimal TotalBalance { get; set; }
    }

    public class Top20ViewModel
    {
        public IEnumerable<Account>? Top20Accounts { get; set; }
    }
}
