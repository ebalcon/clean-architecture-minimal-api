using Domain.Models;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAll();
        Task<User> Get(string id);
        Task<User> Update(User user, string id);
        Task Delete(string id);
    }
}
