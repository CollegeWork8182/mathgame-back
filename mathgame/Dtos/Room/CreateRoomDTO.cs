using mathgame.Dtos.Enums;

namespace mathgame.Dtos.Room;

public record CreateRoomDTO(string Title, string Description, OperationType Operation, DifficultyType Difficulty);