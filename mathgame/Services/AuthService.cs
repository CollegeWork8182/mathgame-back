using System.Net;
using mathgame.Dtos.Auth;
using mathgame.Entities;
using mathgame.Exceptions;
using mathgame.Infra.Gateways;
using mathgame.Utils;

namespace mathgame.Services;

public class AuthService(IUserGateway userGateway, ITokenGateway tokenGateway)
{
    public async Task<LoginResponseDTO> Login(string email, string password)
    {
        var user = await userGateway.FindByEmail(email);
        if(user is null)
            throw new DomainException("Erro ao realizar login");
        
        var result = UtilsMethods.VerifyHashPassword(user, password);
        if (!result)
            throw new DomainException("Erro ao realizar login");
        
        var accessToken = tokenGateway.CreateAccessToken(user);
        return new LoginResponseDTO(accessToken!);
    }
}