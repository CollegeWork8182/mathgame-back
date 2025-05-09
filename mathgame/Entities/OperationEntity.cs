namespace mathgame.Entities
{
    public class OperationEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<DifficultyEntity> Difficulties { get; set; } = null!;
        public ICollection<QuestionEntity> Questions { get; set; } = null!;
        public OperationEntity() { }
        public OperationEntity(long id, string title, ICollection<DifficultyEntity> difficulties, ICollection<QuestionEntity> questions) {
            Id = id;
            Title = title;
            Difficulties = difficulties;
            Questions = questions;
        }
        public OperationEntity(string title, ICollection<DifficultyEntity> difficulties, ICollection<QuestionEntity> questions)
        {
            Title = title;
            Difficulties = difficulties;
            Questions = questions;
        }
    }
}
