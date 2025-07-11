using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace task11;

public interface ICalculator
{
    int Addition(int a, int b);
    int Subtraction(int a, int b);
    int Multiplication(int a, int b);
    int Div(int a, int b);
}

[Generator]
public class CalculationGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        string generated_code = @"
namespace Generated
{
    public class Calculator : task11.ICalculator
    {
        public int Addition(int a, int b) => a + b;
        public int Subtraction(int a, int b) => a - b;
        public int Multiplication(int a, int b) => a * b;
        public int Div(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }
    }
}";

        context.AddSource("GeneratedCalculator", SourceText.From(generated_code, Encoding.UTF8));
    }

    public void Initialize(GeneratorInitializationContext context) { }
}
