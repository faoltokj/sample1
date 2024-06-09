using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.BankApplication;
using WebBankApplication.Services;
using WebBankApplication.ViewModels;
using X.PagedList;

namespace WebBankApplication.Pages
{
    [Authorize(Roles = "Customer")]
    public class CustomersModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomersModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public PageListViewModel PageListView { get; set; }
        public void OnGet(string search)
        {
            int pageNumber = 1;

            if (Request.Query.ContainsKey("page"))
            {
                if (int.TryParse(Request.Query["page"], out int parsedPageNumber))
                {
                    pageNumber = parsedPageNumber;
                }
            }
            int pageSize = 50;

            IEnumerable<Customer> customers;

            if (string.IsNullOrWhiteSpace(search))
            {
                customers = _customerService.GetAllCustomers();
            }
            else
            {
                customers = _customerService.SearchCustomers(search);
            }

            var pageData = customers.ToPagedList(pageNumber, pageSize);

            PageListView = new PageListViewModel
            {
                Customer = pageData,
                ActivePageNumber = pageNumber,
                CurrentPage = pageNumber,
            };

        }

    }
}
