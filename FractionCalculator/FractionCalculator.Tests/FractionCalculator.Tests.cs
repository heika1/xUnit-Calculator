using Xunit;
using FractionCalculator;

namespace FractionCalculator.Tests
{
    public class FractionTests
    {
        [Fact]
        public void Add_TwoPositiveFractions_ReturnsCorrectSum()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            var result = f1.Add(f2);
            Assert.Equal(5, result.Numerator);
            Assert.Equal(6, result.Denominator);
        }

        [Fact]
        public void Subtract_NegativeFromPositive_ReturnsCorrectDifference()
        {
            var f1 = new Fraction(3, 4);
            var f2 = new Fraction(1, 2);
            var result = f1.Subtract(f2);
            Assert.Equal(1, result.Numerator);
            Assert.Equal(4, result.Denominator);
        }

        [Fact]
        public void Multiply_TwoFractions_ReturnsCorrectProduct()
        {
            var f1 = new Fraction(2, 3);
            var f2 = new Fraction(3, 4);
            var result = f1.Multiply(f2);
            Assert.Equal(1, result.Numerator);
            Assert.Equal(2, result.Denominator);
        }

        [Fact]
        public void Divide_FractionByItself_ReturnsOne()
        {
            var f1 = new Fraction(2, 3);
            var result = f1.Divide(f1);
            Assert.Equal(1, result.Numerator);
            Assert.Equal(1, result.Denominator);
        }

        [Fact]
        public void Constructor_ZeroDenominator_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Fraction(1, 0));
            Assert.Equal("Denominator cannot be zero.", exception.Message);
        }

        [Fact]
        public void Divide_ByZeroFraction_ThrowsDivideByZeroException()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(0, 5);
            Assert.Throws<DivideByZeroException>(() => f1.Divide(f2));
        }

        [Fact]
        public void Simplify_NegativeDenominator_MovesSignToNumerator()
        {
            var f = new Fraction(2, -3);
            Assert.Equal(-2, f.Numerator);
            Assert.Equal(3, f.Denominator);
        }
    }
}