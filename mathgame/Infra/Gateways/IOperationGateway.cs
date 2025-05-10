using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IOperationGateway
{
    Task<OperationEntity?> FindByTitle(string title);
}