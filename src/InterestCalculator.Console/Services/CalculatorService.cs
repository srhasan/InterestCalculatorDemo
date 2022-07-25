using InterestCalculator.ConsoleUI.Model;
using Microsoft.Extensions.Logging;
using System;

namespace InterestCalculator.ConsoleUI.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger _logger;
        private readonly CalculatorResolver _calculatorResolver;

        public CalculatorService(
            CalculatorResolver calculatorResolver,
            ILogger<CalculatorService> logger)
        {
            _calculatorResolver = calculatorResolver;
            _logger = logger;
        }

        public double CalculatePrincipalAndInterestAmount(CalculatorUserInput userInput)
        {
            /* TODO: Service layer should do any required validation (not done for demo) and leave calculator to do calculation only
             * 
             * TODO Range 3 - 60 months 
             * At maturity cant be input
             * 
             */
            var calculator = _calculatorResolver(userInput.PaymentInterval);
            var result = calculator.PrincipleAndInterest(userInput);
            return Math.Round(result, MidpointRounding.AwayFromZero); 
        }
    }
}
