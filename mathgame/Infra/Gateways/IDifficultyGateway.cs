using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IDifficultyGateway
{
    Task<DifficultyEntity?> FindByTitle(string title);
}