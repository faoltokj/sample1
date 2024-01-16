namespace WebBankApplication.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string? Gender { get; set; }
        public string? GivenName { get; set; }
        public string? Surname { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public decimal Balance { get; set; }

        public int AccountId { get; set; }

    }
}
