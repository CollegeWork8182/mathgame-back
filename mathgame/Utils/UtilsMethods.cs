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
    
    public static string GenerateCode(int length = 30)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Range(1, length)
            .Select(_ => chars[random.Next(chars.Length)]).ToArray());
    }
}