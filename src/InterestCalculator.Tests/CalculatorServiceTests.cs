using InterestCalculator.ConsoleUI.Services;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using InterestCalculator.ConsoleUI.Model;
using InterestCalculator.ConsoleUI.Calculators;
using InterestCalculator.ConsoleUI.Enums;

namespace InterestCalculator.Tests
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData(50000.2d, 50000d)]
        [InlineData(50000.5d, 50001d)]
        [InlineData(50000.82d, 50001d)]
        public void Validate_Rounding(
            double mockedResult,
            double expectedResult)
        {

            var mockLogger = new Mock<ILogger<CalculatorService>>();
            var mockResolver = new Mock<CalculatorResolver>();
            var mockCalculator = new Mock<ICalculator>();

            mockCalculator.Setup(m => m.PrincipleAndInterest(It.IsAny<CalculatorUserInput>())).Returns(mockedResult);
            mockResolver.Setup(_ => _(It.IsAny<PaymentInterval>())).Returns(mockCalculator.Object);

            var service = new CalculatorService(mockResolver.Object, mockLogger.Object);
            var roundedResult = service.CalculatePrincipalAndInterestAmount(new CalculatorUserInput());

            Assert.Equal(expectedResult, roundedResult);
        }
    }
}
