using Xunit;
using task11;

namespace task11tests
{
    public class OperationsTests
    {
        private readonly ICalculator _calculator;

        public OperationsTests()
        {
            _calculator = new Generated.Calculator();
        }

        [Fact]
        public void TesingAddition()
        {
            Assert.Equal(31, _calculator.Addition(30, 1));
        }

        [Fact]
        public void TestingSubtraction()
        {
            Assert.Equal(44, _calculator.Subtraction(67, 23));
        }

        [Fact]
        public void TesingMultiplication()
        {
            Assert.Equal(45, _calculator.Multiplication(5, 9));
        }

        [Fact]
        public void TestingDiv()
        {
            Assert.Equal(11, _calculator.Div(22, 2));
        }

        [Fact]
        public void WhenDividingByZero_ShouldThrowDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Div(100, 0));
        }
    }
}
