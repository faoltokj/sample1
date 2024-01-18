using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebBankApplication.BankApplication;
using WebBankApplication.Interfaces;
using WebBankApplication.Services;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Pages.Sections.AccountViews
{
    public class AccountManagementModel : PageModel
    {

        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly ITransactionService _transactionService;


        public AccountManagementModel(IAccountService accountService, ICustomerService customerService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _customerService = customerService;
            _transactionService = transactionService;
           
        }

        public AccountViewModel Account { get; private set; }
        public string CustomerName { get; private set; }








        public IActionResult OnGet(int customerId)
        {
            Account = _accountService.GetAccountDetailsByCustomerId(customerId);

            if (Account == null)
            {
                return NotFound();
            }

            // Fetch customer details to get the name
            var customer = _customerService.GetCustomerDetails(customerId);
            if (customer != null)
            {
                CustomerName = $"{customer.GivenName} {customer.Surname}";
            }

            return Page();

        }

     

    }
}