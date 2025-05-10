using mathgame.Entities;
using mathgame.Infra.Gateways;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra.Repositories;

public class UserRepositoryGateway(AppDbContext context) : IUserGateway
{
    public async Task Save(UserEntity user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task<UserEntity?> FindByEmail(string email)
    {
        return await context.Users
            .Include(x => x.Profile)
            .Include(x => x.AccessCode)
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<UserEntity?> FindById(long id)
    {
        return await context.Users
            .Include(x => x.Profile)
            .Include(x => x.AccessCode)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(UserEntity user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
    }
}