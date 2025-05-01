using mathgame.Dtos.User;
using mathgame.Entities;
using mathgame.Exceptions;
using mathgame.Infra.Gateways;
using mathgame.Utils;


namespace mathgame.Services;

public class UserService(IUserGateway userGateway, IProfileGateway profileGateway, AccessCodeService accessCodeService)
{
    public async Task CreateUser(CreateUserDTO data)
    {
        var profile = await profileGateway.FindByRole(data.Role.ToString());
        if(profile is null)
            throw new DomainException("Erro ao criar usuário");
        
        var hashedPassword = UtilsMethods.GenerateHashPassword(data.Password);
        var code = accessCodeService.GenerateAccessCode();
        
        var user = new UserEntity(data.Name, data.Email, hashedPassword, code, profile);

        await userGateway.Save(user);
    }

    public async Task UpdatePassword(UpdatePasswordDTO data)
    {
        var user = await userGateway.FindByEmail(data.UserEmail);
        if (user is null)
            throw new DomainException("Erro ao alterar senha. Por favor verifique as informações e tente novamente");
        if(user.AccessCode!.IsActive)
            throw new DomainException("Código de acesso ainda não validado. Por favor tente novamente");
        var duration = user.AccessCode!.ExperationDate - DateTime.Now;
        if (duration <= TimeSpan.Zero)
            throw new DomainException("Código de acesso expirado. Por favor gere outro e tente novamente");
        if(user.AccessCode.IsUserUpdatePassword)
            throw new DomainException("Código de acesso já utilizado. Por favor gere outro e tente novamente");
        user.Password = UtilsMethods.GenerateHashPassword(data.UserPassword);
        user.AccessCode.IsUserUpdatePassword = true;

        await userGateway.Update(user);
    }
}