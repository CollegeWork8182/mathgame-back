using mathgame.Dtos.AccessCode;
using mathgame.Dtos.Email;
using mathgame.Entities;
using mathgame.Exceptions;
using mathgame.Infra.Gateways;

namespace mathgame.Services;

public class AccessCodeService(IUserGateway userGateway, IEmailGateway emailGateway)
{
    public AccessCodeEntity GenerateAccessCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        var code = new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        var expiration = DateTime.Now.AddMinutes(5);
        
        return new AccessCodeEntity(code, true, false, expiration );
    }

    public async Task VerifyAccessCode(VerifyAccessCodeDTO data)
    {
        var user = await userGateway.FindByEmail(data.UserEmail);
        if (user is null)
             throw new DomainException("Erro ao verificar código de acesso. Por favor verifique as informações e tente novamente");

        if (!user.AccessCode!.IsActive)
            throw new DomainException("Código de acesso já validado. Por favor gere outro e tente novamente");

        if (!user.AccessCode!.Code.Equals(data.AccessCode))
            throw new DomainException("Erro ao verificar código de acesso. Por favor verifique as informações e tente novamente");

        var duration = user.AccessCode!.ExperationDate - DateTime.Now;
        if (duration <= TimeSpan.Zero)
            throw new DomainException("Código de acesso expirado. Por favor gere outro e tente novamente");

        user.AccessCode.IsActive = false;

        await userGateway.Update(user);
    }

    public async Task ResendAccessCode(ResendAccessCodeDTO data)
    {
        var user = await userGateway.FindByEmail(data.UserEmail);
        if (user is null)
            throw new DomainException("Erro ao reenviar código de acesso. Por favor verifique as informações e tente novamente");

        var newAccessCode = this.GenerateAccessCode();
        newAccessCode.Id = user.AccessCode!.Id;
        user.AccessCode = newAccessCode;
        
        await userGateway.Update(user);

        Dictionary<string, Object> variables = new Dictionary<string, Object>();
        variables.Add("username", user.Name);
        variables.Add("accesscode", user.AccessCode.Code);
        
        var emailDto = new SendEmailDTO("", "Alteração de senha", user.Email, variables);
        await emailGateway.Send(emailDto);
    }
}