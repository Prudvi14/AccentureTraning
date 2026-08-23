namespace DependencyInjection.Services
{
    public class StripeService : IPaymentService
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} using Stripe";
        }
    }
}
