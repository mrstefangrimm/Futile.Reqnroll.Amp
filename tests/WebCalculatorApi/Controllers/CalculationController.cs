using Microsoft.AspNetCore.Mvc;
using WebCalculatorApi.Services;

namespace WebCalculatorApi.Controllers;

[Route("api/calculation")]
[ApiController]
public class CalculationController(ICalculationService calculationService) : ControllerBase
{
    [HttpPost]
    public CalculationResponse Post([FromBody] CalcuationRequest request)
    {
        return calculationService.Calculate(request);
    }
}

public record CalcuationRequest(int FirstNumber, int SecondNumber, string MathOperation)
{
}

public record CalculationResponse(double Result)
{
}
