using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.BankApplication;
using WebBankApplication.Services;

namespace WebBankApplication.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomersModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IEnumerable<Customer> Customers { get; set; }
        public int TotalPages { get; set; }

        public void OnGet(int? page, string search)
        {
            const int pageSize = 50;

            int pageNumber = page ?? 1;
            Customers = string.IsNullOrWhiteSpace(search)
                ? _customerService.GetPagedCustomers(pageNumber, pageSize)
                : _customerService.SearchCustomers(search);

            int totalCustomers = string.IsNullOrWhiteSpace(search)
                ? _customerService.GetTotalCustomers()
                : _customerService.SearchTotalCustomers(search);

            TotalPages = (int)Math.Ceiling((double)totalCustomers / pageSize);
        }
    }
}
