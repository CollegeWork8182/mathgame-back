namespace mathgame.Entities
{
    public class OperationEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<OperationDifficultiesEntity> OperationDifficulties { get; set; } = null!;
        public ICollection<QuestionEntity> Questions { get; set; } = null!;
        public OperationEntity() { }
        public OperationEntity(long id, string title, ICollection<OperationDifficultiesEntity> operationDifficulties, ICollection<QuestionEntity> questions) {
            Id = id;
            Title = title;
            OperationDifficulties = operationDifficulties;
            Questions = questions;
        }
        public OperationEntity(string title, ICollection<OperationDifficultiesEntity> operationDifficulties, ICollection<QuestionEntity> questions)
        {
            Title = title;
            OperationDifficulties = operationDifficulties;
            Questions = questions;
        }
    }
}
