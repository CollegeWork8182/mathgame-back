namespace mathgame.Dtos.Report;

public record ReportDTO(
    long RoomId,
    string Title,
    string Description,
    string Operation,
    string Difficulty,
    List<RankingToReportDTO> Ranking,
    List<UserToReportDTO> Users
    );