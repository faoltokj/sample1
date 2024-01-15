using Microsoft.EntityFrameworkCore;
using WebBankApplication.Data;
using WebBankApplication.BankApplication;

namespace WebBankApplication.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankApplicationDataContext _dbContext;

        public AccountService(BankApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public decimal GetTotalBalance()
        {
            return _dbContext.Accounts.Sum(a => a.Balance);
        }

        public IEnumerable<Account> GetTop20Accounts()
        {
            return _dbContext.Accounts.OrderBy(a => a.AccountId).Take(20);
        }

    
    }
}
