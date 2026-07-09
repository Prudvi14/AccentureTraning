using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class CalculatorController : Controller
    {
        [Route("Calculator/Add/{num1}/{num2}")]
        public IActionResult Add(double num1, double num2)
        {
            var result = new CalculatorResult
            {
                Num1 = num1,
                Num2 = num2,
                Operation = "Addition",
                Result = num1 + num2,
                CalculatedAt = DateTime.Now
            };
            return View("Result", result); 
        }

        [Route("Calculator/Sub/{num1}/{num2}")]
        public IActionResult Sub(double num1, double num2)
        {
            var result = new CalculatorResult
            {
                Num1 = num1,
                Num2 = num2,
                Operation = "Subtraction",
                Result = num1 - num2,
                CalculatedAt = DateTime.Now
            };
            return View("Result", result);
        }

        [Route("Calculator/Mul/{num1}/{num2}")]
        public IActionResult Mul(double num1, double num2)
        {
            var result = new CalculatorResult
            {
                Num1 = num1,
                Num2 = num2,
                Operation = "Multiplication",
                Result = num1 * num2,
                CalculatedAt = DateTime.Now
            };
            return View("Result", result);
        }

        [Route("Calculator/Div/{num1}/{num2}")]
        public IActionResult Div(double num1, double num2)
        {
            var result = new CalculatorResult
            {
                Num1 = num1,
                Num2 = num2,
                Operation = "Division",
                CalculatedAt = DateTime.Now
            };

            if (num2 == 0)
            {
                result.Result = 0; 
                ViewBag.Error = "Cannot divide by zero!";
            }
            else
            {
                result.Result = num1 / num2;
            }

            return View("Result", result);
        }
    }
}