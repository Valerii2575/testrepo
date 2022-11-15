using System;
using UqsArithmetic;

namespace Uqs.Arithmetic.Tests.Unit
{
    public class DivisionTests
    {
        public DivisionTests()
        {
        }

        [Fact]
        public void Divide_DivisibleIntegers_WholeNumber()
        {
            //Arrange
            int dividend = 10;
            int divisor = 5;
            decimal exeptedQuotient = 2;

            //Act
            decimal actualQuotient = Division.Divide(dividend, divisor);

            //Assert
            Assert.Equal(exeptedQuotient, actualQuotient);
        }

        [Fact]
        public void Divide_IndivisibleIntegers_DecimalNumber()
        {
            //Arrange
            int dividend = 10;
            int divisor = 4;
            decimal exeptedQuotient = 2.5m;

            //Act
            decimal actualQuotient = Division.Divide(dividend, divisor);

            //Assert
            Assert.Equal(exeptedQuotient, actualQuotient);
        }

        [Fact]
        public void Divide_ZeroDivisor_DevidedByZeroException()
        {
            //Arrange
            int dividend = 10;
            int divisor = 0;

            //Act
            Exception e = Record.Exception(() => Division.Divide(dividend, divisor));

            //Assert
            Assert.IsType<DivideByZeroException>(e);
        }

        [Theory]
        [InlineData(int.MaxValue, int.MinValue, -0.999999999534)]
        [InlineData(-int.MaxValue, int.MinValue, 0.999999999534)]
        [InlineData(int.MinValue, int.MaxValue, -1.000000000466)]
        [InlineData(int.MinValue, -int.MaxValue, 1.000000000466)]
        public void Divide_ExtremInputs_CorrectCalculation(int dividend, int divisor, decimal exeptedQuotient)
        {
            //Arrange
          
            //Act
            decimal actualQuotient = Division.Divide(dividend, divisor);

            //Assert
            Assert.Equal(exeptedQuotient, actualQuotient, 12);
        }
    }
}

