using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebBankApplication.Interfaces;
using WebBankApplication.Services;
using WebBankApplication.BankApplication;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Pages.Sections.AccountViews
{
    public class WithdrawModel : PageModel
    {
        private readonly IAccountService _accountService;

        public WithdrawModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Range(100, 10000)]
        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AccountId { get; set; }
        public void OnGet(int accountId)
        {
            var accountDb = _accountService.GetAccount(accountId);
            Balance = accountDb.Balance;

            // Option 2 - Cleaner?
            // Balance = _accountService.GetAccount(accountId).Balance;
        }

        public IActionResult OnPost()
        {
            var accountDb = _accountService.GetAccount(AccountId); // Use AccountId here
            if (accountDb.Balance < Amount)
            {
                ModelState.AddModelError("Amount", "You don't have that much money!");
            }

            if (ModelState.IsValid)
            {
                accountDb.Balance -= Amount;
                _accountService.Update(accountDb);
            }
            return Page();


        }


    }


}
