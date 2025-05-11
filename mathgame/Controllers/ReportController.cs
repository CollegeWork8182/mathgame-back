using mathgame.Dtos.Report;
using mathgame.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mathgame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    /// <summary>
    /// Buscar um relatório dos resultados de um sala
    /// </summary>
    /// <param name="roomId">Id da sala</param>
    /// <returns></returns>
    [HttpGet("{roomId}")]
    [Authorize(Roles = "ADMIN, PROFESSOR")]
    public async Task<ActionResult<ReportDTO>> FindReport([FromRoute] long roomId, [FromServices] ReportService reportService)
    {
        return Ok(await reportService.FindReport(roomId));
    }
}