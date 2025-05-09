namespace mathgame.Entities
{
    public class ParticipantEntity
    {
        public long Id { get; set; }
        public long QtdResponses { get; set; }
        public ICollection<ResponseEntity>? Responses { get; set; } = null!;
        public UserEntity User { get; set; } = null!;
        public long UserId { get; set; }
        public ICollection<RoomEntity> Rooms { get; set; } = null!;
        public ParticipantEntity() { }
        public ParticipantEntity(long id, long qtdResponses, ICollection<ResponseEntity> responses)
        {
            Id = id;
            QtdResponses = qtdResponses;
            Responses = responses;
        }
        public ParticipantEntity(long qtdResponses, ICollection<ResponseEntity> responses)
        {
            QtdResponses = qtdResponses;
            Responses = responses;
        }
    }
}
