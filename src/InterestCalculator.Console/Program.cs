using InterestCalculator.ConsoleUI.Calculators;
using InterestCalculator.ConsoleUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace InterestCalculator.ConsoleUI
{
    class Program
    {
        private static ILogger<Program> _logger;

        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = ConfigureServiceProvider();

            //do the actual work here
            var app = serviceProvider.GetService<ConsoleApp>();
            _logger = serviceProvider.GetService<ILogger<Program>>();

            _logger.LogInformation("Starting demo app");
            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occured."); // check debug log for further details
                _logger.LogError(ex, "Unhandled Exception");
            }

        }


        private static ServiceProvider ConfigureServiceProvider()
        {
            return new ServiceCollection()
                .AddLogging(configure => configure.AddDebug())
                .AddSingleton<SimpleCalculator>()
                .AddSingleton<CompoundCalculator>()
                .AddSingleton<ConsoleApp>()
                .AddSingleton<ICalculatorService, CalculatorService>()
                .AddTransient<CalculatorResolver>(serviceProvider => key =>
                {
                    switch (key)
                    {
                        case Enums.PaymentInterval.Monthly:
                        case Enums.PaymentInterval.Quaterly:
                        case Enums.PaymentInterval.Annually:
                            return serviceProvider.GetService<CompoundCalculator>();
                        case Enums.PaymentInterval.Maturity:
                            return serviceProvider.GetService<SimpleCalculator>();
                        default:
                            throw new Exception($"Payment interval type '{key.ToString()}' is not supported");
                    }
                })
                .BuildServiceProvider();
        }
    }
}
