using FluentValidation;
using mathgame.Controllers.Validators.Auth;
using mathgame.Dtos.Auth;
using mathgame.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mathgame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(ILogger<UserController> logger) : ControllerBase
{
    /// <summary>
    /// Realizar login
    /// </summary>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginDTO data,
        [FromServices] AuthService authService)
    {
        var validator = new LoginValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.ToString()!);
        
        var result = await authService.Login(data.Email, data.Password);
        return Ok(result);
    } 
}