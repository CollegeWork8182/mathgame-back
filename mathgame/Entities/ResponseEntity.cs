namespace mathgame.Entities
{
    public class ResponseEntity
    {
        public long Id { get; set; }
        public string Correct { get; set; } = string.Empty;
        public string Incorrect { get; set; } = string.Empty;
        public QuestionEntity Question { get; set; } = null!;
        public long QuestionId { get; set; }
        public ParticipantEntity Participant { get; set; } = null!;
        public long ParticipantId { get; set; }
        public ResponseEntity() { }
        public ResponseEntity(long id, string correct)
        {
            Id = id;
            Correct = correct;
        }
        public ResponseEntity(string correct)
        {
            Correct = correct;
        }
    }
}
