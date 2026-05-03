using WebCalculatorApi.Controllers;

namespace WebCalculatorApi.Services;

public interface ICalculationService
{
    CalculationResponse Calculate(CalculationRequest request);
}

public class CalculationService : ICalculationService
{
    public CalculationResponse Calculate(CalculationRequest request)
    {
        return request.MathOperation switch
        {
            "Add" => new CalculationResponse(request.FirstNumber + request.SecondNumber),
            "Subtract" => new CalculationResponse(request.FirstNumber - request.SecondNumber),
            "Multiply" => new CalculationResponse(request.FirstNumber * request.SecondNumber),
            "Divide" => request.SecondNumber != 0
                                ? new CalculationResponse(request.FirstNumber * 1d / request.SecondNumber)
                                : throw new DivideByZeroException("Cannot divide by zero."),
            _ => throw new ArgumentException($"Unknown operation: {request.MathOperation}"),
        };
    }
}
