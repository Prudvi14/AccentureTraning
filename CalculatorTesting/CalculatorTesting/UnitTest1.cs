using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            Calculator calc = new Calculator();
            int result = calc.Add(2, 3);
            Assert.AreEqual(5, result);
        }
    }
}