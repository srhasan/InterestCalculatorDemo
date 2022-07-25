using InterestCalculator.ConsoleUI.Model;
using System;

namespace InterestCalculator.ConsoleUI.Calculators
{
    public class CompoundCalculator : ICalculator
    {
        public double PrincipleAndInterest(CalculatorUserInput input)
        {            
            var rate = input.AnnualRate / 100;

            // P(1 + r/n)^nt
            //https://www.calculatorsoup.com/calculators/financial/compound-interest-calculator.php

            var compound = (int)input.PaymentInterval; // TODO: validate this dont accept others
            var exponent = compound * input.Duration;

            return input.PrincipalAmount * Math.Pow(1 + (rate / compound), exponent);
        }


    }
}
