namespace mathgame.Entities;

public class ProfileEntity
{
    public long Id { get; set; }
    public string Role { get; set; }
    public ICollection<UserEntity> Users { get; set; } = null!;
    public ProfileEntity() { }
    public ProfileEntity(long id, string role, ICollection<UserEntity> users)
    {
        Id = id;
        Role = role;
        Users = users;
    }
}