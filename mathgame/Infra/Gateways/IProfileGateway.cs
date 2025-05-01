using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IProfileGateway
{
    Task<ProfileEntity?> FindByRole(string role);
}