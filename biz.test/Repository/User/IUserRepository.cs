using biz.test.Repository.Generic;

namespace biz.test.Repository.User;

public interface IUserRepository : IGenericRepository<Entities.User>
{
    string HashPassword(string password);
    bool VerifyPassword(string hash, string password);
    string BuildToken(Entities.User user);
    string VerifyEmail(string email);
    string SendMail(string emailTo, string body, string subject);
}