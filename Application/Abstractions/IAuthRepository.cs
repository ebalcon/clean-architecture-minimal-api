using Domain.Models;

namespace Application.Abstractions
{
    public interface IAuthRepository
    {
        Task Register(User user);
        Task<string> Login(string email, string password);
        Task<User> GetCurrent();
    }
}
