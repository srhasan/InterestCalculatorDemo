using InterestCalculator.ConsoleUI.Enums;
using InterestCalculator.ConsoleUI.Model;
using InterestCalculator.ConsoleUI.Services;
using Microsoft.Extensions.Logging;
using System;

namespace InterestCalculator.ConsoleUI
{
    public class ConsoleApp
    {
        private readonly ILogger _logger;
        private readonly ICalculatorService _calculatorService;

        private readonly string _frequencyPrompt =
            "Payment frequency options:" + Environment.NewLine
                + "\t1. Monthly" + Environment.NewLine
                + "\t2. Quarterly" + Environment.NewLine
                + "\t3. Annually" + Environment.NewLine
                + "\t4. At Maturity" + Environment.NewLine
                + "Select frequency:";

        public ConsoleApp(
            ICalculatorService calculatorService,
            ILogger<ConsoleApp> logger)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press ctrl+c to quit anytime");

                var principalAmount = GetUserInput("Deposit amount:", 1000d, 1000000);
                var interestRate = GetUserInput("Enter interest rate (0-5):", 0d, 5d);
                var year = GetUserInput("Investment term in years (0-5):", 0d, 5d);
                var month = GetUserInput("Investment term in months (0-11):", 0, 12);
                var interval = GetPaymentInterval(GetUserInput(_frequencyPrompt, 1, 4));
                var calculatorInput = new CalculatorUserInput
                {
                    PrincipalAmount = principalAmount,
                    AnnualRate = interestRate,
                    Years = year,
                    Months = month,
                    PaymentInterval = interval
                };
                var result = _calculatorService.CalculatePrincipalAndInterestAmount(calculatorInput);

                Console.WriteLine("Calculated principal and interest is: {0}", result);
                Console.WriteLine("Press enter to continue with another calculation");
                Console.ReadLine();
            }
        }

        private double GetUserInput(string prompt, double min, double max)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            double number;
            if (double.TryParse(input, out number))
            {
                if (number >= min && number <= max)
                    return number;
            }
            Console.WriteLine("Invalid input '{0}'. Valid input should be between {1} to {2}", input, min, max);
            return GetUserInput(prompt, min, max);
        }

        private PaymentInterval GetPaymentInterval(double input)
        {
            switch (input)
            {
                case 1:
                    return PaymentInterval.Monthly;
                case 2:
                    return PaymentInterval.Quaterly;
                case 3:
                    return PaymentInterval.Annually;
                case 4:
                    return PaymentInterval.Maturity;
                default:
                    // TODO: Throw or log 
                    return PaymentInterval.NotApplicable;
            }
        }
    }
}
