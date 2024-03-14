using CalculatorTest;

namespace TestCalculator
{

    // Fact va Theory ishlatilgan
    // Exception Test ham yozilgan!
    public class TestsForCalculatorMethods
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2,2,4)]
        [InlineData(100,-90,10)]
        [InlineData(3,2,5)]
        [InlineData(1,20,21)]
        public void PlusTest(double a, double b, double expecteedResult)
        {
            double result = CalculatorMethods.Plus(a, b);
            Assert.Equal(expecteedResult, result);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(-2, -2, 0)]
        [InlineData(-100, -90, -10)]
        [InlineData(3, 2, 1)]
        [InlineData(1, 20, -19)]
        [InlineData(-1, 2, -3)]
        public void MinusTest(double a, double b, double expecteedResult)
        {
            double result = CalculatorMethods.Minus(a, b);
            Assert.Equal(expecteedResult, result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(-2, -2, 4)]
        [InlineData(-100, -90, 9000)]
        [InlineData(3, 2, 6)]
        [InlineData(1, 20, 20)]
        [InlineData(-1, 2, -2)]
        public void MultipleTest(double a, double b, double expecteedResult)
        {
            double result = CalculatorMethods.Multiple(a, b);
            Assert.Equal(expecteedResult, result);
        }

        [Theory]
        [InlineData(8, 2, 4)]
        [InlineData(-2, -2, 1)]
        [InlineData(-10, -1, 10)]
        [InlineData(22, 2, 11)]
        [InlineData(100, 20, 5)]
        [InlineData(12, 6, 2)]
        public void DevideTest(double a, double b, double expecteedResult)
        {
            double result = CalculatorMethods.Devide(a, b);
            Assert.Equal(expecteedResult, result);
        }


        [Fact]
        public void DevideExceptionTest()
        {
            double a = 8;
            double b = 0;

            Action message = () => CalculatorMethods.Devide(a, b);
            DivideByZeroException result = Assert.Throws<DivideByZeroException>(message);

            Assert.Equal(typeof(DivideByZeroException), result.GetType());
        }
    }
}