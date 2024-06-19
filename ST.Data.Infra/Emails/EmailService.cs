using Microsoft.Extensions.Options;
using ST.Core.Application.Interfaces.Infrastructure;
using ST.Core.Infra.Models.Emails;

namespace ST.Data.Infra.Emails
{
  public class EmailService : ISendEmails
  {
    public EmailSettings Settings { get; }

    public EmailService(IOptions<EmailSettings> settings)
    {
      Settings = settings.Value;
    }

    public Task<bool> SendEmail(Email email)
    {
      throw new NotImplementedException();
    }
  }
}
