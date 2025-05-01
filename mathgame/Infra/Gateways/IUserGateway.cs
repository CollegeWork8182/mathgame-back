using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IUserGateway
{
    Task Save(UserEntity user);
    Task<UserEntity?> FindByEmail(string email);
    Task Update(UserEntity user);
}