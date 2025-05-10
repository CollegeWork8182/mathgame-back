using mathgame.Infra.Gateways;
using mathgame.Infra.Repositories;
using mathgame.Services;

namespace mathgame.Config;

public static class IocDependencyExtensions
{
    public static void AddIocDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserGateway, UserRepositoryGateway>();
        services.AddScoped<IProfileGateway, ProfileRepositoryGateway>();
        services.AddScoped<IRoomGateway, RoomRepositoryGateway>();
        services.AddScoped<IDifficultyGateway, DifficultRepositoryGateway>();
        services.AddScoped<IOperationGateway, OperationGatewayRepository>();
        services.AddScoped<ITokenGateway, TokenGateway>();
        services.AddScoped<IEmailGateway, EmailGateway>();
        services.AddScoped<UserService>();
        services.AddScoped<AuthService>();
        services.AddScoped<AccessCodeService>();
        services.AddScoped<RoomService>();
        services.AddScoped<QuestionService>();
    }
}