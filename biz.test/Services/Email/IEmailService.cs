using biz.test.Models.Email;

namespace biz.test.Services.Email;

public interface IEmailService
{
    string SendEmail(EmailModel email);
    string SendEmailAttach(EmailModelAttach email);
}