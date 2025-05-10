using mathgame.Entities;
using mathgame.Infra.Gateways;
using Microsoft.EntityFrameworkCore;

namespace mathgame.Infra.Repositories;

public class QuestionRepositoryGateway(AppDbContext context) : IQuestionGateway
{
    public async Task<QuestionEntity?> FindById(long id)
    {
        return await context.Questions.FirstOrDefaultAsync(x => x.Id == id);
    }
}