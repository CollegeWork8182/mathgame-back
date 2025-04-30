using mathgame.Entities;
using mathgame.Infra.Gateways;

namespace mathgame.Infra.Repositories;

public class UserRepositoryGateway(AppDbContext context) : IUserGateway
{
    public async Task Save(UserEntity user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
    }
}