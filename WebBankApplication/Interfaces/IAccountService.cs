using WebBankApplication.BankApplication;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        decimal GetTotalBalance();
        IEnumerable<Account> GetTop20Accounts();

        AccountViewModel GetAccountDetailsByCustomerId(int customerId);

        List<Account> GetAccounts();
        void Update(Account account);
        Account GetAccount(int accountId);

        void Withdraw(int accountId, decimal amount);
    }
}
