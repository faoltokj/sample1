#nullable disable
using WebBankApplication.BankApplication;
using X.PagedList;

namespace WebBankApplication.ViewModels
{
    public class PageListViewModel
    {
        public IPagedList<Customer> Customer { get; set; }
        public int ActivePageNumber { get; set; }
        public int CurrentPage { get; set; }
    }
}
