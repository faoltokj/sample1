using WebBankApplication.BankApplication;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BankApplicationDataContext _dbContext;

        public CustomerService(BankApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public int GetTotalCustomers()
        {
            return _dbContext.Customers.Count();
        }

        public IEnumerable<Customer> GetPagedCustomers(int page, int pageSize)
        {
            return _dbContext.Customers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Customer> SearchCustomers(string searchTerm)
        {
            return _dbContext.Customers
                .Where(c => c.Givenname.Contains(searchTerm) || c.Surname.Contains(searchTerm) || c.City.Contains(searchTerm))
                .ToList();
        }

        public int SearchTotalCustomers(string searchTerm)
        {
            return _dbContext.Customers
                .Count(c => c.Givenname.Contains(searchTerm) || c.Surname.Contains(searchTerm) || c.City.Contains(searchTerm));
        }

        public CustomerViewModel GetCustomerDetails(int customerId)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return null;
            }

            var account = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == customerId);

            return new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                Gender = customer.Gender,
                GivenName = customer.Givenname,
                Surname = customer.Surname,
                StreetAddress = customer.Streetaddress,
                City = customer.City,
                Country = customer.Country,
                TelephoneNumber = customer.Telephonenumber,
                EmailAddress = customer.Emailaddress,
                Balance = account?.Balance ?? 0 // Get the balance if the account exists, otherwise default to 0
            };
        }


    }
}
