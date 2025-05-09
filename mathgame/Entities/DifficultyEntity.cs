namespace mathgame.Entities
{
    public class DifficultyEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<RoomEntity> Rooms { get; set; } = null!;
        public ICollection<OperationEntity> Operations { get; set; } = null!;
        public DifficultyEntity() { }
        public DifficultyEntity(long id, string title, ICollection<OperationEntity> operations) 
        {
            Id = id;
            Title = title;
            Operations = operations;
        }
        public DifficultyEntity(string title, ICollection<OperationEntity> operations)
        {
            Title = title;
            Operations = operations;
        }
    }
}
