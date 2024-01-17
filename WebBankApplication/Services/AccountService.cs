using Microsoft.EntityFrameworkCore;
using WebBankApplication.Data;
using WebBankApplication.BankApplication;
using WebBankApplication.ViewModels;

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

       
        public AccountViewModel GetAccountDetailsByCustomerId(int accountId)
        {
            var accountEntity = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);

            if (accountEntity == null)
            {
                // Handle the case where the account is not found
                return null;
            }

            // Map the data from the Entity (Account) to the ViewModel (AccountViewModel)
            var accountViewModel = new AccountViewModel
            {
                AccountId = accountEntity.AccountId,
                Balance = accountEntity.Balance,
                Created = accountEntity.Created
                // Add other properties as needed
            };

            // Return the AccountViewModel instance
            return accountViewModel;
        }

        public List<Account> GetAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetAccount(int accountId)
        {
            return _dbContext.Accounts.First(a => a.AccountId == accountId);
        }

        public void Update(Account account)
        {
            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
        }


        public void Withdraw(int accountId, decimal amount)
        {
            var account = _dbContext.Accounts.Find(accountId);

            if (account != null)
            {
                // Update account balance
                account.Balance -= amount;

                // Save changes to the database
                _dbContext.SaveChanges();
            }
        }


    }


}

