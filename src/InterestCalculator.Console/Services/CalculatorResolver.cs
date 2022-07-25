using InterestCalculator.ConsoleUI.Calculators;
using InterestCalculator.ConsoleUI.Enums;

namespace InterestCalculator.ConsoleUI.Services
{
    // Resolves the calculator with factory pattern with DI
    public delegate ICalculator CalculatorResolver(PaymentInterval paymentInterval);
}
