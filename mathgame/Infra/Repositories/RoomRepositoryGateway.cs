using mathgame.Entities;
using mathgame.Infra.Gateways;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra.Repositories;

public class RoomRepositoryGateway(AppDbContext context) : IRoomGateway
{
    public async Task Save(RoomEntity room)
    {
        context.Rooms.Add(room);
        await context.SaveChangesAsync();
    }

    public async Task<List<RoomEntity>> FindAll(long userId)
    {
        return await context.Rooms
            .Where(x => x.User.Id == userId 
                        || x.Participants!.Any(p => p.User.Id == userId)
                        )
            .ToListAsync();
    }

    public async Task<RoomEntity?> FindById(long roomId)
    {
        return await context.Rooms
            .Include(x => x.OperationDifficulties).ThenInclude(x => x.Operation)
            .Include(x => x.OperationDifficulties).ThenInclude(x => x.Difficulty)
            .Include(x => x.Participants!).ThenInclude(x => x.Responses)
            .FirstOrDefaultAsync(x => x.Id == roomId);
    }

    public async Task Update(RoomEntity room)
    {
        context.Rooms.Update(room);
        await context.SaveChangesAsync();
    }
}