
using FluentValidation;
using mathgame.Controllers.Validators.User;
using mathgame.Dtos;
using mathgame.Dtos.User;
using mathgame.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mathgame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ILogger<UserController> logger) : ControllerBase
{
    /// <summary>
    /// Criar um novo usuário
    /// </summary>
    /// <remarks>
    /// Para as Roles temos as seguintes: 1 = ADMIN, 2 = PROFESSOR, 3 = STUDENT
    /// </remarks>
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<MessageSuccessDTO>> CreateUser([FromBody] CreateUserDTO data,
        [FromServices] UserService userService)
    {
        var validator = new CreateUserValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        await userService.CreateUser(data);
        
        return Ok(new MessageSuccessDTO("Usuário Criado com sucesso!"));
    }
    
    /// <summary>
    /// Alterar senha do usuário
    /// </summary>
    [AllowAnonymous]
    [HttpPut("password")]
    public async Task<ActionResult<MessageSuccessDTO>> Update([FromBody] UpdatePasswordDTO data, [FromServices] UserService userService)
    {
        var validator = new UpdatePasswordValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        await userService.UpdatePassword(data);

        return Ok(new MessageSuccessDTO("Senha alterada com sucesso"));
    }
}