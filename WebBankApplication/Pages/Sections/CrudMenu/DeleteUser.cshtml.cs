using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.Interfaces;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Pages.Sections.CrudMenu
{
    public class DeleteUserModel : PageModel
    {

        private readonly IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<UserViewModel> Users { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve a list of all users from the service
            Users = _userService.GetAllUsers();

            return Page();
        }
    }

}
