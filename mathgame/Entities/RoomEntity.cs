namespace mathgame.Entities
{
    public class RoomEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public OperationDifficultiesEntity OperationDifficulties { get; set; }
        public long OperationDifficultiesId { get; set; }
        public UserEntity User { get; set; } = null!;
        public long UserId { get; set; }
        public ICollection<ParticipantEntity>? Participants { get; set; } = null!;
        public RoomEntity() { }
        public RoomEntity(long id, string title, string description, string code, string status, OperationDifficultiesEntity operationDifficulties, UserEntity user)
        {
            Id = id;
            Title = title;
            Description = description;
            Code = code;
            Status = status;
            OperationDifficulties = operationDifficulties;
            User = user;
        }
        public RoomEntity(string title, string description, string code, string status, OperationDifficultiesEntity operationDifficulties, UserEntity user)
        {
            Title = title;
            Description = description;
            Code = code;
            Status = status;
            OperationDifficulties = operationDifficulties;
            User = user;
        }
    }
}
