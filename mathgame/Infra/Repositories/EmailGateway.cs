using System.Net;
using System.Net.Mail;
using mathgame.Dtos.Email;
using mathgame.Infra.Gateways;
using Scriban;

namespace mathgame.Infra.Repositories;

public class EmailGateway(IConfiguration configuration) : IEmailGateway
{
    public async Task Send(SendEmailDTO emailDto)
    {
        var client = InitializeClient();

        var body = CreateTemplate(emailDto);
        emailDto.EmailBody = body;

        var message = CreateMessage(emailDto);
        
        await client.SendMailAsync(message);
    }

    private SmtpClient InitializeClient()
    {
        var mailSettings = configuration.GetSection("MailSettings");
        var host = mailSettings.GetValue<string>("Host");
        var port = mailSettings.GetValue<int>("Port");
        var username = mailSettings.GetValue<string>("UserName");
        var password = mailSettings.GetValue<string>("Password");
        
        var client = new SmtpClient(host, port);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(username, password);

        return client;
    }
    
    private MailMessage CreateMessage(SendEmailDTO data)
    {
        var mailSettings = configuration.GetSection("MailSettings");
        var emailId = mailSettings.GetValue<string>("EmailId");
        
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(emailId!);
        mailMessage.To.Add(data.Recipient);
        mailMessage.Subject = data.Subject;
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = data.EmailBody;
        
        return mailMessage;
    }

    private string CreateTemplate(SendEmailDTO data)
    {
        var emailBody = GetFileTemplate();
        var template = Template.Parse(emailBody);

        var directory = Directory.GetCurrentDirectory();

        return template.Render(data.Variables);
    }

    private string GetFileTemplate()
    {
        var directory = Directory.GetCurrentDirectory();
        var filePath = Path.Combine(directory, "Infra", "Templates", "update-password-template.html");
        return File.ReadAllText(filePath);
    }
}