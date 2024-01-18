using WebBankApplication.ViewModels;

namespace WebBankApplication.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUserById(string userId);

        List<UserViewModel> GetAllUsers();
    }
}
