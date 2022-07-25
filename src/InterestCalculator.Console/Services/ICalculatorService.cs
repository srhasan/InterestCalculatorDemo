using InterestCalculator.ConsoleUI.Model;

namespace InterestCalculator.ConsoleUI.Services
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Calculate total Principal and interest amount based on user input. Result is rounded to nearest number.
        /// </summary>
        /// <param name="userInput"></param>
        public double CalculatePrincipalAndInterestAmount(CalculatorUserInput userInput);
    }
}
