using Microsoft.EntityFrameworkCore;
using WebBankApplication.BankApplication;
using WebBankApplication.Interfaces;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Services
{
    public class UserService : IUserService
    {

        private readonly BankApplicationDataContext _dbContext;

        public UserService(BankApplicationDataContext dbContext)
        {
            _dbContext = dbContext;

        }
        public UserViewModel GetUserById(string userId)
        {
            // Assuming you have a User entity in your database
            var userEntity = _dbContext.AspNetUsers
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            if (userEntity == null)
            {
                return null;
            }

            // Map the entity properties to the ViewModel
            var userViewModel = new UserViewModel
            {
                Id = Guid.Parse(userEntity.Id), // Convert string to Guid
                UserName = userEntity.UserName,
                Email = userEntity.Email,
                // Map other properties as needed
            };

            return userViewModel;
        }

        public List<UserViewModel> GetAllUsers()
        {
            // Assuming you have a User entity in your database
            var users = _dbContext.AspNetUsers
                .Select(u => new UserViewModel
                {
                    Id = Guid.Parse(u.Id),
                    UserName = u.UserName,
                    Email = u.Email,
                    // Map other properties as needed
                })
                .ToList();

            return users;
        }

    }

}
