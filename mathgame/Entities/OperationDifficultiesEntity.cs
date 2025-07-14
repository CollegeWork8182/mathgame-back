namespace mathgame.Entities;

public class OperationDifficultiesEntity
{
    public long Id { get; set; }
    public OperationEntity Operation { get; set; } = null!;
    public long OperationId { get; set; }
    public DifficultyEntity Difficulty { get; set; } = null!;
    public long DifficultyId { get; set; }
    public RoomEntity Room { get; set; } = null!;
    public ICollection<QuestionEntity> Questions { get; set; } = null!;
    public OperationDifficultiesEntity() { }

    public OperationDifficultiesEntity(long operationId, long difficultyId)
    {
        OperationId = operationId;
        DifficultyId = difficultyId;
    }
}