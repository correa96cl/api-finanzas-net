using CashFlow.Application;
using CashFlow.Communication;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{

    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {

        try
        {
            var useCase = new RegisterExpenseUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var errorResponse = new ResponseErrorJson(ex.Message);
            return BadRequest(errorResponse);


        }
        catch (DivideByZeroException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson("Unknown Error");
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }

    }

}