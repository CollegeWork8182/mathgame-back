namespace mathgame.Entities
{
    public class OperationEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<OperationDifficultiesEntity> OperationDifficulties { get; set; } = null!;
        public OperationEntity() { }
        public OperationEntity(long id, string title, ICollection<OperationDifficultiesEntity> operationDifficulties) {
            Id = id;
            Title = title;
            OperationDifficulties = operationDifficulties;
        }
        public OperationEntity(string title, ICollection<OperationDifficultiesEntity> operationDifficulties)
        {
            Title = title;
            OperationDifficulties = operationDifficulties;
        }
    }
}
