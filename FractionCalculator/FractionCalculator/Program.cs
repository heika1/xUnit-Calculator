using System;

namespace FractionCalculator
{
    // Клас для представлення дробу
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        // Спрощення дробу
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;

            // Знаменник завжди позитивний
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        // Найбільший спільний дільник
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Операції з дробами
        public Fraction Add(Fraction other)
        {
            int newNumerator = Numerator * other.Denominator + other.Numerator * Denominator;
            int newDenominator = Denominator * other.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Subtract(Fraction other)
        {
            int newNumerator = Numerator * other.Denominator - other.Numerator * Denominator;
            int newDenominator = Denominator * other.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Multiply(Fraction other)
        {
            return new Fraction(Numerator * other.Numerator, Denominator * other.Denominator);
        }

        public Fraction Divide(Fraction other)
        {
            if (other.Numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero fraction.");
            return new Fraction(Numerator * other.Denominator, Denominator * other.Numerator);
        }

        public override string ToString() => $"{Numerator}/{Denominator}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fraction Calculator");
            Console.WriteLine("Enter fractions in format 'numerator/denominator'");

            try
            {
                Console.Write("Enter first fraction: ");
                var frac1 = ParseFraction(Console.ReadLine());
                Console.Write("Enter second fraction: ");
                var frac2 = ParseFraction(Console.ReadLine());

                Console.WriteLine($"Addition: {frac1.Add(frac2)}");
                Console.WriteLine($"Subtraction: {frac1.Subtract(frac2)}");
                Console.WriteLine($"Multiplication: {frac1.Multiply(frac2)}");
                Console.WriteLine($"Division: {frac1.Divide(frac2)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static Fraction ParseFraction(string input)
        {
            var parts = input.Split('/');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int num) || !int.TryParse(parts[1], out int den))
                throw new FormatException("Invalid fraction format. Use 'numerator/denominator'.");
            return new Fraction(num, den);
        }
    }
}
