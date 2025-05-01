using mathgame.Entities;
using mathgame.Infra.Gateways;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra.Repositories;

public class ProfileRepositoryGateway(AppDbContext context) : IProfileGateway
{
    public async Task<ProfileEntity?> FindByRole(string role)
    {
        return await context.Profiles.FirstOrDefaultAsync(x => x.Role == role);
    }
}