using mathgame.Entities;

namespace mathgame.Utils;

using static BCrypt.Net.BCrypt;

public class UtilsMethods
{
    public static string GenerateHashPassword(string password)
    {
        var workFactor = 12;
        var hashedPassword = HashPassword(password, workFactor);
        
        return hashedPassword;
    }
    
    public static bool VerifyHashPassword(UserEntity user, string password)
    {
        var passwordMatch = Verify(password, user.Password);
        return passwordMatch;
    }
}