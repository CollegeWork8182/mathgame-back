using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IUserGateway
{
    Task Save(UserEntity user);
}