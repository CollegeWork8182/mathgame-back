using mathgame.Entities;
using mathgame.Infra.Gateways;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra.Repositories;

public class DifficultRepositoryGateway(AppDbContext context) : IDifficultyGateway
{
    public async Task<DifficultyEntity?> FindByTitle(string title)
    {
        return await context.Difficulties
            .Include(x => x.OperationDifficulties)
            .FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
    }
}