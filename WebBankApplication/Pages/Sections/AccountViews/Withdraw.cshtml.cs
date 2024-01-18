using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebBankApplication.Interfaces;
using WebBankApplication.Services;
using WebBankApplication.BankApplication;
using WebBankApplication.ViewModels;
using Microsoft.AspNetCore.Routing;


namespace WebBankApplication.Pages.Sections.AccountViews
{
    public class WithdrawModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public WithdrawModel(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        [BindProperty]
        [Range(100, 10000)]
        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AccountId { get; set; }
        public int CustomerId { get; set; }

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

            if (accountDb.Balance < Amount)
            {
                ModelState.AddModelError("Amount", "You don't have that much money!");
            }

            if (ModelState.IsValid)
            {
                accountDb.Balance -= Amount;
                _accountService.Update(accountDb);
                Balance = accountDb.Balance;

            }
            return Page();
        }


    }


}
