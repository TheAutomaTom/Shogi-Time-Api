using ST.Core.Infra.Models.Emails;

namespace ST.Core.Application.Interfaces.Infrastructure
{
  public interface ISendEmails
  {
    Task<bool> SendEmail(Email email);
  }
}
