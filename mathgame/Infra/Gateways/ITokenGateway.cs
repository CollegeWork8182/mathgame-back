using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface ITokenGateway
{
    string? CreateAccessToken(UserEntity user);
}