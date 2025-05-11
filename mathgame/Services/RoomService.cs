using mathgame.Dtos.Enums;
using mathgame.Dtos.Room;
using mathgame.Entities;
using mathgame.Exceptions;
using mathgame.Infra.Gateways;
using mathgame.Utils;
using Microsoft.OpenApi.Models;

namespace mathgame.Services;

public class RoomService(IRoomGateway roomGateway, IUserGateway userGateway, IDifficultyGateway difficultyGateway, IOperationGateway operationGateway)
{
    public async Task CreateRoom(CreateRoomDTO data, long userId)
    {
        var user = await userGateway.FindById(userId);
        if(user is null)
            throw new DomainException("Erro ao criar sala");

        var difficulty = await difficultyGateway.FindByTitle(data.Difficulty.ToString());
        if(difficulty is null)
            throw new DomainException("Erro ao criar sala");
        
        var operation = await operationGateway.FindByTitle(data.Operation.ToString());
        if(operation is null)
            throw new DomainException("Erro ao criar sala");

        var difficultyAndOperation = difficulty.OperationDifficulties
            .FirstOrDefault(x => x.OperationId == operation.Id);
        
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        
        var code = new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        
        var room = new RoomEntity(
            data.Title,
            data.Description,
            code,
            StatusRoomType.CREATED.ToString(),
            difficultyAndOperation!,
            user
            );

        await roomGateway.Save(room);
    }
    public async Task<List<FindAllMyRoomsResponseDTO>> FindAllMyRooms(long userId)
    {
        var user = await userGateway.FindById(userId);
        if(user is null)
            return new List<FindAllMyRoomsResponseDTO>();

        var rooms = await roomGateway.FindAll(userId);
        return rooms.Select(x => new FindAllMyRoomsResponseDTO(x.Id, x.Title)).ToList();
    }

    public async Task UpdateRoom(UpdateRoomDTO data, long roomId)
    {
        var room = await roomGateway.FindById(roomId);
        
        if(room.Status.ToString() == StatusRoomType.FINISHED.ToString())
            throw new DomainException("Turma finalizada");
        
        var difficulty = await difficultyGateway.FindByTitle(data.Difficulty.ToString());
        if(difficulty is null)
            throw new DomainException("Erro ao atualizar informações");
        
        var operation = await operationGateway.FindByTitle(data.Operation.ToString());
        if(operation is null)
            throw new DomainException("Erro ao atualizar informações");
        
        var difficultyAndOperation = difficulty.OperationDifficulties
            .FirstOrDefault(x => x.OperationId == operation.Id);
        
        room.Title = data.Title;
        room.Description = data.Description;
        room.OperationDifficulties = difficultyAndOperation;
        
        await roomGateway.Update(room);
    }
    public async Task<ShareAccessCodeDTO> ShareAccessCode(long roomId)
    {
        var room = await roomGateway.FindById(roomId);
        if(room!.Status.ToString() == StatusRoomType.FINISHED.ToString() || room.Status.ToString() == StatusRoomType.STARTED.ToString())
            throw new DomainException("Turma iniciada ou já finalizada");
        
        return new ShareAccessCodeDTO(room.Code);
    }

    public async Task EnterTheRoom(long roomId, long userId)
    {
        var room = await roomGateway.FindById(roomId);
        if(room.Status.ToString() == StatusRoomType.STARTED.ToString() || room.Status.ToString() == StatusRoomType.FINISHED.ToString())
            throw new DomainException("Turma já iniciada ou finalizada");
        
        var user = await userGateway.FindById(userId);

        if (room == null || user == null)
            throw new DomainException("Erro ao adicionar usuário");
        
        if (room.Participants != null && room.Participants.Any(p => p.UserId == userId))
            throw new DomainException("Erro ao adicionar usuário");

        var newParticipant = new ParticipantEntity(user, null);

        newParticipant.Rooms = new List<RoomEntity> { room };

        if (room.Participants == null)
            room.Participants = new List<ParticipantEntity>();

        room.Participants.Add(newParticipant);

        await roomGateway.Update(room);
    }

    public async Task<FindByRoomIdDTO> FindById(long roomId)
    {
        var room = await roomGateway.FindById(roomId);

        return new FindByRoomIdDTO(room.Id, room.Title, room.Description, room.OperationDifficulties.Operation.Title,
            room.OperationDifficulties.Difficulty.Title, room.Code, room.Status);
    }

    public async Task UpdateStatus(long roomId, StatusRoomType status)
    {
        var room = await roomGateway.FindById(roomId);
        
        if(status.ToString() == StatusRoomType.CREATED.ToString())
            throw new DomainException("Essa turma já existe");
        
        room.Status = status.ToString();
    }
}