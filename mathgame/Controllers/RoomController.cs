using FluentValidation;
using mathgame.Controllers.Validators.Room;
using mathgame.Dtos;
using mathgame.Dtos.Room;
using mathgame.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mathgame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    /// <summary>
    /// Criar um sala
    /// </summary>
    /// <remarks>
    /// Para Difficult temos: EASY, MEDIUM, HARD
    /// Para Operation temos: ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION
    /// </remarks>
    [HttpPost]
    [Authorize(Roles = "ADMIN, PROFESSOR")]
    public async Task<ActionResult<MessageSuccessDTO>> Create([FromBody] CreateRoomDTO data, [FromServices] RoomService roomService)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null) return Unauthorized();
        
        var validator = new CreateRoomValidator();
        var validationResult = await validator.ValidateAsync(data);
        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        await roomService.CreateRoom(data, long.Parse(userIdClaim));

        return Ok(new MessageSuccessDTO("Sala criada com sucesso"));
    }

    /// <summary>
    /// Retornar todas as minhas salas criadas ou que já participei
    /// </summary>
    [HttpGet("all/me")]
    [Authorize(Roles = "ADMIN, PROFESSOR, STUDENT")]
    public async Task<ActionResult<List<FindAllMyRoomsResponseDTO>>> FindAllMyRooms(
        [FromServices] RoomService roomService)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null) return Unauthorized();

        return Ok(roomService.FindAllMyRooms(long.Parse(userIdClaim)));
    }
    
    /// <summary>
    /// Alterar informações de uma sala
    /// </summary>
    /// <remarks>
    /// Para Difficult temos: 1 = EASY, 2 = MEDIUM, 3 = HARD
    /// Para Operation temos: 1 = ADDITION, 2 = SUBTRACTION, 3 = MULTIPLICATION, 4 = DIVISION
    /// </remarks>
    /// <param name="roomId">Id da sala</param>
    [HttpPut("{roomId}")]
    [Authorize(Roles = "ADMIN, PROFESSOR")]
    public async Task<ActionResult<MessageSuccessDTO>> Update([FromBody] UpdateRoomDTO data, [FromRoute] long roomId, [FromServices] RoomService roomService)
    {
        var validator = new UpdateRoomValidator();
        var validationResult = await validator.ValidateAsync(data);
        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        await roomService.UpdateRoom(data, roomId);

        return Ok(new MessageSuccessDTO("Sala criada com sucesso"));
    }

    /// <summary>
    /// Compartilhar código de acesso da sala 
    /// </summary>
    /// <param name="roomId">Id da sala</param>
    [HttpGet("shareAccessCode/{roomId}")]
    [Authorize(Roles = "ADMIN, PROFESSOR")]
    public async Task<ActionResult<ShareAccessCodeDTO>> ShareAccessCode([FromRoute] long roomId,
        [FromServices] RoomService roomService)
    {
        return Ok(await roomService.ShareAccessCode(roomId));
    }

    /// <summary>
    /// Entrar dentro da sala
    /// </summary>
    /// <param name="roomId">Id da sala</param>
    /// <returns></returns>
    [HttpPost("enter/{roomId}")]
    [Authorize(Roles = "ADMIN, STUDENT")]
    public async Task<ActionResult<MessageSuccessDTO>> EnterTheRoom([FromRoute] long roomId,
        [FromServices] RoomService roomService)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null) return Unauthorized();
        
        await roomService.EnterTheRoom(roomId, long.Parse(userIdClaim));
        return Ok(new MessageSuccessDTO("Participação realizada com sucesso"));
    }

    /// <summary>
    /// Retorna informações da sala por id
    /// </summary>
    /// <param name="roomId">Id da sala</param>
    [HttpGet("{roomId}")]
    [Authorize(Roles = "ADMIN, PROFESSOR, STUDENT")]
    public async Task<ActionResult<FindByRoomIdDTO>> FindById([FromRoute] long roomId, [FromServices] RoomService roomService)
    {
        return Ok(await roomService.FindById(roomId));
    }

    /// <summary>
    /// Altera o status de uma sala
    /// </summary>
    /// <remarks>
    /// Para o status temos: STARTED, FINISHED
    /// </remarks>
    /// <param name="roomId">Id da sala</param>
    [HttpPut("status/{roomId}")]
    [Authorize(Roles = "ADMIN, PROFESSOR")]
    public async Task<ActionResult<MessageSuccessDTO>> UpdateStatus([FromBody] UpdateStatusDTO data,  [FromRoute] long roomId, [FromServices] RoomService roomService)
    {
        var validator = new UpdateStatusValidator();
        var validationResult = await validator.ValidateAsync(data);
        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        await roomService.UpdateStatus(roomId, data.Status);
        return Ok(new MessageSuccessDTO("Status alterado com sucesso"));
    }
}