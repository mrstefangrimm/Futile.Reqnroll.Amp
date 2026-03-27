using CalculatorComparison.Specs.Apps;

namespace CalculatorComparison.Specs.Services;

public class WebApiCalculatorService(WebApiCalculatorApiClient api)
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public string MathOperator { get; set; }

    public WebApiCalculatorApiClient App { get; } = api;
}
