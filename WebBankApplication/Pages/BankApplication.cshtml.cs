using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.BankApplication;
using WebBankApplication.Services;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Pages
{
    public class BankApplicationModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        public BankApplicationModel(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

      

        public HomeViewModel ViewModel { get; set; }

      

        public void OnGet()
        {


            ViewModel = new HomeViewModel
            {
                TotalCustomers = _customerService.GetTotalCustomers(),
                TotalAccounts = _accountService.GetAllAccounts().Count(),
                TotalBalance = _accountService.GetTotalBalance()
            };



         
        }
    }
}

//public class AccountViewModel
//{
//    public int Id { get; set; }
//    public DateTime Created { get; set; }

//    public decimal Balance { get; set; }

//}



//public List<AccountViewModel> AccountInfo { get; set; } = new List<AccountViewModel>();



//AccountInfo = _dbContext.Accounts.Select(s => new AccountViewModel
//{
//    Id = s.AccountId,
//    Created = s.Created,
//    Balance = s.Balance,
//}).ToList();