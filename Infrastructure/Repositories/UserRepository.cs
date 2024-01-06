using Application.Abstractions;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext _sqlContext;

        public UserRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task Delete(string id)
        {
            var user = await _sqlContext.Users.Where(x => x.Id == Guid.Parse(id)).FirstOrDefaultAsync();

            if (user is null)
                throw new Exception();

            _sqlContext.Users.Remove(user);
            await _sqlContext.SaveChangesAsync();

            return;
        }

        public async Task<User> Get(string id)
        {
            var user = await _sqlContext.Users.Where(x => x.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            return user is null ? throw new Exception() : user;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _sqlContext.Users.ToListAsync();
        }

        public async Task<User> Update(User user, string id)
        {
            var currentUser = await _sqlContext.Users.Where(x => x.Id == Guid.Parse(id)).FirstOrDefaultAsync();

            if (currentUser is null)
                throw new Exception();

            currentUser.Username = user.Username;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;

            return user;
        }
    }
}
