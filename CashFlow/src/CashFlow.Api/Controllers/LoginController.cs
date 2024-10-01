using System;

namespace CashFlow.Api.Controllers;

using global::CashFlow.Application.UseCases.Login.DoLogin;
using global::CashFlow.Communication;
using global::CashFlow.Communication.Requests;
using global::CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromServices] IDoLoginUseCase useCase,
        [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
}