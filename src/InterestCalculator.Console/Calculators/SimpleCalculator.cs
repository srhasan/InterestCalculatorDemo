using InterestCalculator.ConsoleUI.Model;

namespace InterestCalculator.ConsoleUI.Calculators
{
    public class SimpleCalculator : ICalculator
    {
        public double PrincipleAndInterest(CalculatorUserInput input)
        {
            // P(1 + rt)
            // https://www.calculatorsoup.com/calculators/financial/simple-interest-plus-principal-calculator.php

            var rate = input.AnnualRate / 100;
            return input.PrincipalAmount * (1 + (rate * input.Duration));
        }
    }
}
