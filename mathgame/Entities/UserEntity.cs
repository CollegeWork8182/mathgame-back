namespace mathgame.Entities;

public class UserEntity
{
    public long Id { get; set; }
    public string Name {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
    public AccessCodeEntity AccessCode { get; set; }
    public ProfileEntity Profile { get; set; } = null!;
    public long ProfileId { get; set; }
    public ICollection<RoomEntity>? Rooms { get; set; } = null!;
    public ParticipantEntity? Participant { get; set; } = null!;
    
    public UserEntity() { }

    public UserEntity(string name, string email, string password, AccessCodeEntity accessCode, ProfileEntity profile)
    {
        Name = name;
        Email = email;
        Password = password;
        AccessCode = accessCode;
        Profile = profile;
    }
    
    public UserEntity(long id, string name, string email, string password, AccessCodeEntity accessCode, ProfileEntity profile)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        AccessCode = accessCode;
        Profile = profile;
    }
}