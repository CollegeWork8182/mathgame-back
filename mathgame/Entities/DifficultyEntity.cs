namespace mathgame.Entities
{
    public class DifficultyEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<OperationDifficultiesEntity> OperationDifficulties { get; set; } = null!;
        public DifficultyEntity() { }
        public DifficultyEntity(long id, string title, ICollection<OperationDifficultiesEntity> operationDifficulties) 
        {
            Id = id;
            Title = title;
            OperationDifficulties = operationDifficulties;
        }
        public DifficultyEntity(string title, ICollection<OperationDifficultiesEntity> operationDifficulties)
        {
            Title = title;
            OperationDifficulties = operationDifficulties;
        }
    }
}
