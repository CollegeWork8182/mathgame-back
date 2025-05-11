using mathgame.Dtos.Report;
using mathgame.Infra.Gateways;

namespace mathgame.Services;

public class ReportService(IRoomGateway roomGateway, IUserGateway userGateway)
{
    public async Task<ReportDTO> FindReport(long roomId)
    {
        var room = await roomGateway.FindById(roomId);
    
        var participants = room!.Participants!.OrderBy(x => x.Score);

        return new ReportDTO(
            room.Id,
            room.Title,
            room.Description,
            room.OperationDifficulties.Operation.Title,
            room.OperationDifficulties.Difficulty.Title,
            participants.Select(x => new RankingToReportDTO(x.User.Name, x.Score)).ToList(),
            participants.Select(x => new UserToReportDTO(x.User.Id, x.User.Name)).ToList()
        );
    }
}