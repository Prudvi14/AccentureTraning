namespace DependencyInjection.Services
{
    public class RazorpayService: IPaymentService
    {
        public string Pay(decimal amount)
        {
            return $"Paid {amount} using Razorpay";
        }
    }
}
