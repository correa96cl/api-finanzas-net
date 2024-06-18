using CashFlow.Application;
using CashFlow.Communication;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase{

    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request){

        try{
        var useCase = new RegisterExpenseUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
       } catch (ArgumentException ex){
        return BadRequest(ex.Message);

       } catch (DivideByZeroException ex){
        return BadRequest(ex.Message);
       }
       catch {
        return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
       }
   
    }

}