using Microsoft.EntityFrameworkCore;
using WebBankApplication.BankApplication;
using WebBankApplication.Interfaces;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BankApplicationDataContext _dbContext;

        public TransactionService(BankApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TransactionViewModel> GetTransactionHistory(int customerId, int skip, int take)
        {
            var transactions = _dbContext.Transactions
                .Where(t => t.AccountNavigation.AccountId == customerId)
                .OrderByDescending(t => t.Date)
                .Skip(skip)
                .Take(take)
                .Select(t => new TransactionViewModel
                {
                    TransactionId = t.TransactionId,
                    Date = t.Date,
                    Operation = t.Operation,
                    Amount = t.Amount,
                    Balance = t.Balance
                })
                .ToList();

            return transactions;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _dbContext.Customers.Find(customerId);
        }

        public string Withdraw(int sourceAccountId, int targetAccountId, decimal amount)
        {
            // Fetch the source account
            var sourceAccount = _dbContext.Accounts.Find(sourceAccountId);

            // Fetch the target account
            var targetAccount = _dbContext.Accounts.Find(targetAccountId);

            if (sourceAccount == null || targetAccount == null)
            {
                return "Source or target account not found";
            }

            if (sourceAccount.Balance < amount)
            {
                return "Insufficient funds";
            }

            // Update source account balance
            sourceAccount.Balance -= amount;

            // Update target account balance
            targetAccount.Balance += amount;

            // Create a new transaction for source account
            var sourceTransaction = new Transaction
            {
                AccountId = sourceAccountId,
                Date = DateTime.Now,
                Type = "Withdrawal",
                Operation = "Withdraw",
                Amount = -amount,  // Withdrawals are negative values
                Balance = sourceAccount.Balance,
            };

            // Create a new transaction for target account
            var targetTransaction = new Transaction
            {
                AccountId = targetAccountId,
                Date = DateTime.Now,
                Type = "Deposit",
                Operation = "Deposit",
                Amount = amount,
                Balance = targetAccount.Balance,
            };

            // Save changes to the database
            _dbContext.Transactions.Add(sourceTransaction);
            _dbContext.Transactions.Add(targetTransaction);

            // Update both accounts in the database
            _dbContext.Accounts.Update(sourceAccount);
            _dbContext.Accounts.Update(targetAccount);

            _dbContext.SaveChanges();

            return "Success";
        }

        public void AddTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }



    }


}
