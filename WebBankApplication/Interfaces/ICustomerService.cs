using WebBankApplication.BankApplication;

namespace WebBankApplication.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        int GetTotalCustomers();
        IEnumerable<Customer> GetPagedCustomers(int page, int pageSize);

        public IEnumerable<Customer> SearchCustomers(string searchTerm);
        public int SearchTotalCustomers(string searchTerm);

    }
}
