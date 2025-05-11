namespace mathgame.Dtos.Question;

public record FindQuestionsAnsweredDTO(long QuestionId, string Title, string CorrectOption, string Option1, string Option2, string Option3, bool QuestionRight);