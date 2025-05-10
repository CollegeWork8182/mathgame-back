using mathgame.Entities;
using mathgame.Infra.Gateways;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra.Repositories;

public class OperationGatewayRepository(AppDbContext context) : IOperationGateway
{
    public async Task<OperationEntity?> FindByTitle(string title)
    {
        return await context.Operations.FirstOrDefaultAsync(x => x.Title == title);
    }
}