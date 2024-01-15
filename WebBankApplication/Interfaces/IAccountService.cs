using WebBankApplication.BankApplication;

namespace WebBankApplication.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        decimal GetTotalBalance();
        IEnumerable<Account> GetTop20Accounts();

    }
}
