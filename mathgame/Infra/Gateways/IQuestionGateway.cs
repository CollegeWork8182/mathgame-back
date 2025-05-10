using mathgame.Entities;

namespace mathgame.Infra.Gateways;

public interface IQuestionGateway
{
    Task<QuestionEntity?> FindById(long id);
}