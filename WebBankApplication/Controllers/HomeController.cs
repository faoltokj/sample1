using Microsoft.AspNetCore.Mvc;
using WebBankApplication.Services;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public HomeController(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {

            var totalCustomers = _customerService.GetTotalCustomers();
            var totalAccounts = _accountService.GetAllAccounts().Count();
            var totalBalance = _accountService.GetTotalBalance();

            var viewModel = new HomeViewModel
            {
                TotalCustomers = totalCustomers,
                TotalAccounts = totalAccounts,
                TotalBalance = totalBalance
            };

            return View(viewModel);

        }

        public IActionResult ShowTop20()
        {
            var top20Accounts = _accountService.GetTop20Accounts();

            var viewModel = new Top20ViewModel
            {
                Top20Accounts = top20Accounts
            };

            return View(viewModel);
        }


    }
}


