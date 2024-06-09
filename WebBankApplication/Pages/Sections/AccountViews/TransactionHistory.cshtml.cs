using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.BankApplication;
using WebBankApplication.Interfaces;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Pages.Sections.AccountViews
{
    public class TransactionHistoryModel : PageModel
    {
        private readonly ITransactionService _transactionService;

        public TransactionHistoryModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public List<TransactionViewModel> Transactions { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int TransactionsPerPage { get; set; }

        public IActionResult OnGet(int customerId)
        {
            CustomerId = customerId;

            // Fetch customer information
            Customer = _transactionService.GetCustomerById(customerId);

            if (Customer == null)
            {
                // Handle the case where the customer is not found
                // You might want to redirect or show an error message
                return NotFound();
            }

            // Load the first 20 transactions
            LoadTransactions(0, 20);

            return Page();
        }

        public IActionResult OnGetMore(int skip, int take, int customerId)
        {
            take += skip;
            var moreTransactions = _transactionService.GetTransactionHistory(customerId, skip, take);
            return new JsonResult(moreTransactions);
        }


        private void LoadTransactions(int skip, int take)
        {
            Transactions = _transactionService.GetTransactionHistory(CustomerId, skip, take);
        }
    }
}

