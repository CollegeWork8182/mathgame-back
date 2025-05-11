namespace mathgame.Entities
{
    public class QuestionEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CorrectOption { get; set; } = string.Empty;
        public string Option1 { get; set; } = string.Empty;
        public string Option2 { get; set; } = string.Empty;
        public string Option3 { get; set; } = string.Empty;
        public OperationDifficultiesEntity OperationDifficulties { get; set; }
        public long OperationDifficultiesId { get; set; }
        public ICollection<ResponseEntity>? Responses { get; set; } = null!;
        public QuestionEntity() { }
        public QuestionEntity(long id, string title, string correctOption, string option1, string option2, string option3, OperationDifficultiesEntity operationDifficulties, ICollection<ResponseEntity>? responses)
        {
            Id = id;
            Title = title;
            CorrectOption = correctOption;
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            OperationDifficulties = operationDifficulties;
            Responses = responses;
        }
        public QuestionEntity(string title, string correctOption, string option1, string option2, string option3, OperationDifficultiesEntity operationDifficulties, ICollection<ResponseEntity>? responses)
        {
            Title = title;
            CorrectOption = correctOption;
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            OperationDifficulties = operationDifficulties;
            Responses = responses;
        }
    }
}
