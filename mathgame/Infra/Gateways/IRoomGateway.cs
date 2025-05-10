using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IRoomGateway
{
    Task Save(RoomEntity room);
    Task<List<RoomEntity>> FindAll(long userId);
    Task<RoomEntity?> FindById(long roomId);
    Task Update(RoomEntity room);
}