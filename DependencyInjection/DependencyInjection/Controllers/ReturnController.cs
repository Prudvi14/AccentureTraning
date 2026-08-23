using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IPaymentService _paymentService;

        public ReturnController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            string result = _paymentService.Pay(-200);   // refund example
            return Content("Refund: " + result);
        }
    }
}
