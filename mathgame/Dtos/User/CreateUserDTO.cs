using mathgame.Dtos.Enums;

namespace mathgame.Dtos.User;

public record CreateUserDTO(string Name, string Email, string Password, RoleType Role);