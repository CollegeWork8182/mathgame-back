namespace mathgame.Entities
{
    public class ResponseEntity
    {
        public long Id { get; set; }
        public bool Correct { get; set; } = false;
        public bool Incorrect { get; set; } = false;
        public QuestionEntity Question { get; set; } = null!;
        public long QuestionId { get; set; }
        public ParticipantEntity Participant { get; set; } = null!;
        public long ParticipantId { get; set; }
        public ResponseEntity() { }
        public ResponseEntity(long id, bool correct)
        {
            Id = id;
            Correct = correct;
        }
        public ResponseEntity(QuestionEntity question)
        {
            Question = question;
        }
    }
}
