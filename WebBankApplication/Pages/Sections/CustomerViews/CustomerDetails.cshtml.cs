using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.Services;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Pages.Sections.CustomerViews
{
   
    public class CustomerDetailsModel : PageModel
    {

        private readonly ICustomerService _customerService;

        public CustomerDetailsModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public CustomerViewModel Customer { get; private set; }

        public IActionResult OnGet(int customerId)
        {
            Customer = _customerService.GetCustomerDetails(customerId);

            if (Customer == null)
            {
                return NotFound();
            }


            return Page();
        }

    }
}
