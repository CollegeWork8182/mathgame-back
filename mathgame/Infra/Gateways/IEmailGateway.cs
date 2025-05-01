using mathgame.Dtos.Email;

namespace mathgame.Infra.Gateways;

public interface IEmailGateway
{
    Task Send(SendEmailDTO emailDto);
}