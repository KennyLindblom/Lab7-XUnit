using Labb7_XUnit;

namespace Labb7_XUnit_Test
{
    public class CalculatorTestX
    {
        [Fact]
        public void Add_10_To_7_Exspect_17()
        {
            Calculator calculator = new Calculator();

            var exspected = 17;


            var actual = calculator.Add(10, 7);

            Assert.Equal(exspected, actual);
           
        }
        [Fact]
        public void Subtract_5_From_10_Exspect_5()
        {
            Calculator calculator = new Calculator();
            var exspected = 5;

            var actual = calculator.Subtract(10, 5);

            Assert.Equal(exspected, actual);
        }

        [Theory]
        [InlineData(100, 2 , 50)]
        [InlineData(6, 2, 3)]
        [InlineData(2500, 2, 1250)]
        [InlineData(66, 6, 11)]
        [InlineData(100, 100, 1)]

        public void DivideUsingInlineData(int num1, int num2, int exspected)
        {
            Calculator calculator = new Calculator();

            var actucal = calculator.Divide(num1, num2);

            Assert.Equal(exspected, actucal);

        }
        [Theory]
        [InlineData(6,6,36)]
        [InlineData(2, 2, 4)]
        [InlineData(5, 5, 25)]
        [InlineData(1256, 20, 25120)]
        [InlineData(-35, 4, -140)]

        public void MultiplyUsingInlineData(int num1, int num2, int exspected)
        {
            Calculator calculator = new Calculator();

            var actual = calculator.Multiply(num1, num2);

            Assert.Equal(exspected, actual);

        }
    }
}