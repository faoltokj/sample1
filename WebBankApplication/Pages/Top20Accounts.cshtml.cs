using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.BankApplication;
using WebBankApplication.Services;

namespace WebBankApplication.Pages
{
    public class Top20AccountsModel : PageModel
    {
        private readonly IAccountService _accountService;

        public Top20AccountsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IEnumerable<Account> Top20Accounts { get; set; }

        public void OnGet()
        {
            Top20Accounts = _accountService.GetTop20Accounts();
        }
    }
}
