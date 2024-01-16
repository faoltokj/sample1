using WebBankApplication.BankApplication;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Interfaces
{
    public interface ITransactionService
    {
        List<TransactionViewModel> GetTransactionHistory(int customerId, int skip, int take);

        Customer GetCustomerById(int customerId);

        string  Withdraw(int sourceAccountId, int targetAccountId, decimal amount );

        void AddTransaction(Transaction transaction);

    }
}
