using mathgame.Dtos.Enums;
using mathgame.Dtos.Question;
using mathgame.Entities;
using mathgame.Exceptions;
using mathgame.Infra.Gateways;

namespace mathgame.Services;

public class QuestionService(IUserGateway userGateway, IRoomGateway roomGateway, IQuestionGateway questionGateway)
{
    public async Task<FindQuestionDTO?> FindQuestion(long roomId, long userId)
    {
        var room = await roomGateway.FindById(roomId);
        if(room is null)
            throw new DomainException("Sala não encontrada");
        
        if(room.Status.ToString() == StatusRoomType.CREATED.ToString() || room.Status.ToString() == StatusRoomType.FINISHED.ToString())
            throw new DomainException("Turma ainda não iniciada ou finalizada");
        
        var participant = room!.Participants!.FirstOrDefault(x => x.UserId == userId);
        participant!.Responses ??= new List<ResponseEntity>();

        if (participant.QtdResponses == 10)
            throw new DomainException("Perguntas finalizadas");
        
        var responses = participant!.Responses;
        
        var questions = room.OperationDifficulties.Questions;

        var answeredIds = responses.Select(x => x.Question.Id).ToHashSet();
        var unansweredQuestions = questions
            .Where(q => !answeredIds.Contains(q.Id))
            .ToList();

        var random = new Random();
        var randomQuestion = unansweredQuestions.Count > 0
            ? unansweredQuestions[random.Next(0, unansweredQuestions.Count)]
            : null;
        
        var positionQuestion = answeredIds.Count() + 1;
        
        var randomPositionQuestion = random.Next(0, 4);

        return randomPositionQuestion switch
        {
            0 => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.CorrectOption, randomQuestion.Option1,
                randomQuestion.Option2, randomQuestion.Option3, positionQuestion, participant.Score),
            1 => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.Option1, randomQuestion.CorrectOption,
                randomQuestion.Option2, randomQuestion.Option3, positionQuestion, participant.Score),
            2 => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.Option1, randomQuestion.Option2,
                randomQuestion.CorrectOption, randomQuestion.Option3, positionQuestion, participant.Score),
            _ => new FindQuestionDTO(randomQuestion.Id, randomQuestion.Title, randomQuestion.Option1, randomQuestion.Option2,
                randomQuestion.Option3, randomQuestion.CorrectOption, positionQuestion, participant.Score)
        };
    }

    public async Task SendResponseQuestion(long questionId, long userId, long roomId, string response)
    {
        var room = await roomGateway.FindById(roomId);
        if (room is null)
            throw new DomainException("Sala não encontrada");
        
        var question = room.OperationDifficulties.Questions.FirstOrDefault(x => x.Id == questionId);
        if(question is null)
            throw new DomainException("Essa questão não corresponde com a operação e dificuldade escolhidas para essa sala");

        var participants = room!.Participants;
        var participant = room!.Participants!.FirstOrDefault(x => x.UserId == userId);
        participant!.Responses ??= new List<ResponseEntity>();

        var newResponse = new ResponseEntity(question!);
        newResponse.Correct = question!.CorrectOption == response ? true : false;
        newResponse.Incorrect = !newResponse.Correct;

        participant.Responses.Add(newResponse);
        
        participant.QtdResponses++;
        var qtdCorrectResponses = participant.Responses.Count(x => x.Correct);
        
        participant.Score = participant.Score + qtdCorrectResponses;
        
        var isFinalized = participants!.Any(x => x.QtdResponses != 10);
        if(!isFinalized)
            room.Status = StatusRoomType.FINISHED.ToString();
            
        await roomGateway.Update(room);
    }

    public async Task<List<FindQuestionsAnsweredDTO>> FindQuestionsAnswered(long roomId, long userId)
    {
        var room = await roomGateway.FindById(roomId);
        var user = await userGateway.FindById(userId);
        if (room is null || user is null)
            throw new DomainException("Sala ou usuário não encontrada");
        
        var participant = room.Participants.FirstOrDefault(x => x.UserId == userId);
        if (participant is null)
            throw new DomainException("Participante não encontrado na sala");

        var responses = participant.Responses;

        var questionsWithStatus = responses.Select(response =>
        {
            var question = response.Question;
            return new FindQuestionsAnsweredDTO(
                question.Id,
                question.Title,
                question.CorrectOption,
                question.Option1,
                question.Option2,
                question.Option3,
                response.Correct
            );
        }).ToList();

        return questionsWithStatus;
    }
}