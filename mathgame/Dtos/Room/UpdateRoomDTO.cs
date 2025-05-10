using mathgame.Dtos.Enums;

namespace mathgame.Dtos.Room;

public record UpdateRoomDTO(string Title, string Description, OperationType Operation, DifficultyType Difficulty);