namespace mathgame.Entities;

public class AccessCodeEntity
{
    public long Id { get;  set; }
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get;  set; } = true;
    public bool IsUserUpdatePassword { get;  set; } = false;
    public DateTime ExperationDate { get;  set; }
    public long UserId { get; set; }
    public UserEntity User { get; set; }
    
    public AccessCodeEntity() { }
    
    public AccessCodeEntity(long id, string code, bool isActive, bool isUserUpdatePassword, DateTime experationDate)
    {
        Id = id;
        Code = code;
        IsActive = isActive;
        IsUserUpdatePassword = isUserUpdatePassword;
        ExperationDate = experationDate;
    }
    
    public AccessCodeEntity(string code, bool isActive, bool isUserUpdatePassword, DateTime experationDate)
    {
        Code = code;
        IsActive = isActive;
        IsUserUpdatePassword = isUserUpdatePassword;
        ExperationDate = experationDate;
    }
}