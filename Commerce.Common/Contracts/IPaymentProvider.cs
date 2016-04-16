namespace Commerce.Common.Contracts
{
    public interface IPaymentProvider
    {
        bool ProcessCreditCard(string customerName, string creditCard, string expirationDate, double amount);
        string Login { get; set; }
        string Password { get; set; }
    }
}