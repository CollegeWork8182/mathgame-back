using FluentValidation;
using mathgame.Controllers.Validators.Question;
using mathgame.Dtos;
using mathgame.Dtos.Question;
using mathgame.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mathgame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    /// <summary>
    /// Retorna uma questão do quiz
    /// </summary>
    /// <param name="roomId">Id da sala</param>
    [HttpGet("{roomId}")]
    [Authorize(Roles = "ADMIN, STUDENT")]
    public async Task<ActionResult<FindQuestionDTO>> FindQuestion([FromRoute] long roomId,
        [FromServices] QuestionService questionService)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null) return Unauthorized();
        
        return Ok(await questionService.FindQuestion(roomId, long.Parse(userIdClaim)));
    }

    /// <summary>
    /// Envia uma resposta para uma questão
    /// </summary>
    /// <param name="questionId">Id da questão</param>
    /// <param name="roomId">Id da sala</param>
    [HttpPost("{questionId}/room/{roomId}/send/response")]
    [Authorize(Roles = "ADMIN, STUDENT")]
    public async Task<ActionResult<MessageSuccessDTO>> SendResponseQuestion([FromRoute] long questionId, long roomId, [FromBody] SendResponseDTO data,
        [FromServices] QuestionService questionService)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null) return Unauthorized();
        
        var validator = new SendResponseValidator();
        var validationResult = await validator.ValidateAsync(data);
        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        await questionService.SendResponseQuestion(questionId, long.Parse(userIdClaim), roomId, data.Response);

        return Ok(new MessageSuccessDTO("Resposta enviada com sucesso"));
    }

    /// <summary>
    /// Buscar todas as questões respondidas de um usuário para aquela sala
    /// </summary>
    /// <param name="roomId">Id da sala</param>
    /// <param name="userId">Id do usuário</param>
    [HttpGet("all/me/answer")]
    [Authorize(Roles = "ADMIN, PROFESSOR")]
    public async Task<ActionResult<FindQuestionsAnsweredDTO>> FindQuestionsAnsewered([FromQuery] long roomId, long userId,
        [FromServices] QuestionService questionService)
    {
        return Ok(await questionService.FindQuestionsAnswered(roomId, userId));
    }
    
}