using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IUserGateway
{
    Task Save(UserEntity user);
    Task<UserEntity?> FindByEmail(string email);
    Task<UserEntity?> FindById(long id);
    Task Update(UserEntity user);
}