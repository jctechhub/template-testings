using System;

namespace xunit.calculatorTests
{
    public class Calculator //
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        private int AddThenSubtract(int x, int y)
        {
            return x + y - 1;
        }

    }

    public class SpecialCalculator
    {
        private ICalculatorSpecialFunctionsInterface _function;

        public SpecialCalculator(ICalculatorSpecialFunctionsInterface function)
        {
            _function = function;
        }

        public string GetFinalResult()
        {
            return $"final result is: {_function.DividedBy2(10, "Mocking of Prefix")}";
        }
    }

    public class SpecialPrefix
    {
        public string ResultPrefix { get; set; }
    }

    /// <summary>
    /// This is to illustrate the use of Mocking 
    /// </summary>
    public interface ICalculatorSpecialFunctionsInterface
    {
        string DividedBy2(int input, string resultPrefix);
    }

    public class CalculatorSpecialFunctions : ICalculatorSpecialFunctionsInterface
    {
        public string DividedBy2(int input, string resultPrefix)
        {
            return $"{resultPrefix}: {input / 2}";
        }
    }
}
