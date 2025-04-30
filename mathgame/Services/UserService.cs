using mathgame.Dtos.User;
using mathgame.Entities;
using mathgame.Infra.Gateways;
using mathgame.Utils;


namespace mathgame.Services;

public class UserService(IUserGateway userGateway, IProfileGateway profileGateway)
{
    public async Task CreateUser(CreateUserDTO data)
    {
        var profile = await profileGateway.FindByRole(data.Role.ToString());
        
        var hashedPassword = UtilsMethods.GenerateHashPassword(data.Password); 
        var code = UtilsMethods.GenerateCode();
        
        var user = new UserEntity(data.Name, data.Email, hashedPassword, code, profile);

        await userGateway.Save(user);
    }
}