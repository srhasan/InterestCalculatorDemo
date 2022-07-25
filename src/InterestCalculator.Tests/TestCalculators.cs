using InterestCalculator.ConsoleUI.Calculators;
using InterestCalculator.ConsoleUI.Enums;
using InterestCalculator.ConsoleUI.Model;
using System;
using Xunit;

namespace InterestCalculator.Tests
{
    public class TestCalculators
    {
        private readonly ICalculator _compoundCalculator;
        private readonly ICalculator _simpleCalculator;

        public TestCalculators()
        {
            _compoundCalculator = new CompoundCalculator();
            _simpleCalculator = new SimpleCalculator();
        }


        [Theory]
        [InlineData(1000d, 1.1d, PaymentInterval.Monthly, 0, 3, 1003d)]
        [InlineData(10000d, 1.1d, PaymentInterval.Monthly, 0, 5, 10046d)]
        [InlineData(10000d, 1.1d, PaymentInterval.Monthly, 3, 0, 10335d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Monthly, 3, 0, 51677d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Monthly, 2, 11, 51629d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Monthly, 4, 4, 52440d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Quaterly, 0, 3, 50138d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Quaterly, 0, 7, 50321d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Quaterly, 1, 11, 51064d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Annually, 1, 3, 50688d)]
        [InlineData(50000d, 1.1d, PaymentInterval.Annually, 2, 0, 51106d)]
        public void Validate_Compound_Calculation(
            double principalAmount,
            double annualRate,
            PaymentInterval paymentInterval,
            int years,
            int months,
            double expectedResult)
        {

            var result = _compoundCalculator.PrincipleAndInterest(
                new CalculatorUserInput
                {
                    PrincipalAmount = principalAmount,
                    AnnualRate = annualRate,
                    PaymentInterval = paymentInterval,
                    Years = years,
                    Months = months
                });

            result = Math.Round(result, MidpointRounding.AwayFromZero);

            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(50000d, 1.1d, 1, 5, 50779d)]
        [InlineData(50000d, 2.2d, 3, 4, 53667d)]
        public void Validate_Simple_Calculation(
            double principalAmount,
            double annualRate,
            int years,
            int months,
            double expectedResult)
        {

            var result = _simpleCalculator.PrincipleAndInterest(new CalculatorUserInput
            {
                PrincipalAmount = principalAmount,
                AnnualRate = annualRate,
                Years = years,
                Months = months
            });
            result = Math.Round(result, MidpointRounding.AwayFromZero);
            Assert.Equal(expectedResult, result);
        }

    }
}
