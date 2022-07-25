using InterestCalculator.ConsoleUI.Enums;

namespace InterestCalculator.ConsoleUI.Model
{
    public class CalculatorUserInput
    {
        public double PrincipalAmount { get; set; }
        public double AnnualRate { get; set; }
        public PaymentInterval PaymentInterval { get; set; }
        public double Years { private get; set; }
        public double Months { private get; set; }

        public double Duration
        {
            get
            {
                return ((Years * 12) + Months) / 12d;
            }
        }
    }
}
