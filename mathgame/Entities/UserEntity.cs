namespace mathgame.Entities;

public class UserEntity
{
    public long Id { get; set; }
    public string Name {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
    public string PasswordChangeCode {get; set;} = string.Empty;
    public ProfileEntity Profile { get; set; } = null!;
    
    public long ProfileId { get; set; }
    
    public UserEntity() { }

    public UserEntity(string name, string email, string password, string passwordChangeCode, ProfileEntity profile)
    {
        Name = name;
        Email = email;
        Password = password;
        PasswordChangeCode = passwordChangeCode;
        Profile = profile;
    }
    
    public UserEntity(long id, string name, string email, string password, ProfileEntity profile)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Profile = profile;
    }
}