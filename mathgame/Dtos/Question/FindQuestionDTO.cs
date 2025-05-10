namespace mathgame.Dtos.Question;

public record FindQuestionDTO(long Id, string Title, string Option1, string Option2, string Option3, string Option4, int PositionQuestion, long Score);