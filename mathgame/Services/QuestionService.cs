using mathgame.Dtos.Question;
using mathgame.Entities;
using mathgame.Infra.Gateways;

namespace mathgame.Services;

public class QuestionService(IUserGateway userGateway, IRoomGateway roomGateway, IQuestionGateway questionGateway)
{
    public async Task<FindQuestionDTO?> FindQuestion(long roomId, long userId)
    {
        var room = await roomGateway.FindById(roomId);
        
        var participant = room!.Participants!.FirstOrDefault(x => x.User.Id == userId);
        participant.Responses ??= new List<ResponseEntity>();
        
        var responses = participant!.Responses;
        
        var operation = room.OperationDifficulties.Operation;

        var answeredIds = responses.Select(x => x.Question.Id).ToHashSet();
        var unansweredQuestions = operation.Questions
            .Where(q => !answeredIds.Contains(q.Id))
            .ToList();

        var random = new Random();
        var randomQuestion = unansweredQuestions.Count > 0
            ? unansweredQuestions[random.Next(0, unansweredQuestions.Count)]
            : null;
        
        var positionQuestion = answeredIds.Count() + 1;

        var score = responses.Count > 0 ? 10 - responses.Select(x => x.Correct == true).Count() : 0; 
        
        var randomPositionQuestion = random.Next(0, 4);

        return randomPositionQuestion switch
        {
            0 => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.CorrectOption, randomQuestion.Option1,
                randomQuestion.Option2, randomQuestion.Option3, positionQuestion, score),
            1 => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.Option1, randomQuestion.CorrectOption,
                randomQuestion.Option2, randomQuestion.Option3, positionQuestion, score),
            2 => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.Option1, randomQuestion.Option2,
                randomQuestion.CorrectOption, randomQuestion.Option3, positionQuestion, score),
            _ => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.Option1, randomQuestion.Option2,
                randomQuestion.Option3, randomQuestion.CorrectOption, positionQuestion, score)
        };
    }

    public async Task SendResponseQuestion(long questionId, long userId, long roomId, string response)
    {
        var room = await roomGateway.FindById(roomId);
        var question = await questionGateway.FindById(questionId);
        
        var participant = room!.Participants!.FirstOrDefault(x => x.User.Id == userId);
        participant.Responses ??= new List<ResponseEntity>();
        
        var responses = participant!.Responses;

        var newResponse = new ResponseEntity(question);
        newResponse.Correct = question.CorrectOption == response ? true : false;
        newResponse.Incorrect = !newResponse.Correct;
        
        participant.Responses.Add(newResponse);

        await roomGateway.Update(room);

    }
}