using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IPaymentService _paymentService;

        public SubscriptionController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            string result = _paymentService.Pay(1000);
            return Content("Subscription: " + result);
        }
    }
}
