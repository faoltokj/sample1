using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebBankApplication.Services;

namespace WebBankApplication.Pages.Sections.AccountViews
{
    public class TransferModel : PageModel
    {

        private readonly IAccountService _accountService;

        public TransferModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        [Range(100, 10000)]
        public decimal Amount { get; set; }

        [BindProperty]
        public int TargetAccountId { get; set; }

        public decimal Balance { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AccountId { get; set; }

        public void OnGet(int accountId)
        {
            Console.WriteLine($"OnGet method called. AccountId: {accountId}");
            AccountId = accountId;
            var accountDb = _accountService.GetAccount(accountId);
            Balance = accountDb.Balance;
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("OnPost method called.");  // Add this line for debugging

            // You can directly use the AccountId property
            var accountDb = _accountService.GetAccount(AccountId);

            if (accountDb == null)
            {
                // Handle the case where the account is not found
                // You can return an error message or perform other actions.
                Console.WriteLine("Can't find account");
            }

            // Check if there is enough balance for the transfer
            if (accountDb.Balance < Amount)
            {
                ModelState.AddModelError("Amount", "Not enough money for the transfer!");
                return Page();
            }

            // Perform transfer logic
            accountDb.Balance -= Amount;
            _accountService.Update(accountDb);

            // You need to implement logic to find and update the target account
            // For simplicity, I assume there is a similar Update method in IAccountService
            var targetAccountDb = _accountService.GetAccount(TargetAccountId);

            if (targetAccountDb != null)
            {
                targetAccountDb.Balance += Amount;
                _accountService.Update(targetAccountDb);
            }
            else
            {
                // Handle the case where the target account is not found
                // You can return an error message or perform other actions.
                Console.WriteLine("Can't find target account");
            }

            Balance = accountDb.Balance;

            return Page();
        }
    }

}
