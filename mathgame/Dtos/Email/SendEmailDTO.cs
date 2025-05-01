namespace mathgame.Dtos.Email;

public class SendEmailDTO
{
    public string EmailBody;
    public string Subject;
    public string Recipient;
    public Dictionary<string, Object> Variables;

    public SendEmailDTO(string emailBody, string subjet, string recipient, Dictionary<string, Object> variables)
    {
        EmailBody = emailBody;
        Subject = subjet;
        Recipient = recipient;
        Variables = variables;
    }
}