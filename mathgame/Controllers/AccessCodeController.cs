using FluentValidation;
using mathgame.Controllers.Validators.AccessCode;
using mathgame.Dtos;
using mathgame.Dtos.AccessCode;
using mathgame.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mathgame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccessCodeController : ControllerBase
{
    /// <summary>
    /// Verificar código de acesso
    /// </summary>
    [AllowAnonymous]
    [HttpPost("verify")]
    public async Task<ActionResult<MessageSuccessDTO>> VerifyCode([FromBody] VerifyAccessCodeDTO data, [FromServices] AccessCodeService accessCodeService)
    {
        var validator = new VerifyAccessCodeValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        await accessCodeService.VerifyAccessCode(data);

        return Ok(new MessageSuccessDTO("Código de acesso verificado com sucesso"));
    }
    /// <summary>
    /// Reenviar código de acesso
    /// </summary>
    [AllowAnonymous]
    [HttpPost("resend")]
    public async Task<ActionResult<MessageSuccessDTO>> ResendAccessCode([FromBody] ResendAccessCodeDTO data, [FromServices] AccessCodeService accessCodeService)
    {
        var validator = new ResendAccessCodeValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.ToString()!);
        await accessCodeService.ResendAccessCode(data);

        return Ok(new MessageSuccessDTO("Código de acesso reenviado com sucesso"));
    }
}