
using mathgame.Controllers.Validators.User;
using mathgame.Dtos;
using mathgame.Dtos.User;
using mathgame.Exceptions;
using mathgame.Services;
using Microsoft.AspNetCore.Mvc;

namespace mathgame.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ILogger<UserController> logger) : ControllerBase
{
    /// <summary>
    /// Criar um novo usuário
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<MessageSuccessDTO>> CreateUser([FromBody] CreateUserDTO data,
        [FromServices] UserService userService)
    {
        var validator = new CreateUserValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }
        
        await userService.CreateUser(data);
        
        return Ok(new MessageSuccessDTO("Usuário Criado com sucesso!"));
    }
}