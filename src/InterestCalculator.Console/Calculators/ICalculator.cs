using InterestCalculator.ConsoleUI.Model;

namespace InterestCalculator.ConsoleUI.Calculators
{
    public interface ICalculator
    {
        public double PrincipleAndInterest(CalculatorUserInput input);
    }
}
