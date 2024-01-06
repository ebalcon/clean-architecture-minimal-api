using Application.Abstractions;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SqlContext _sqlContext;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthRepository(SqlContext sqlContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _sqlContext = sqlContext;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetCurrent()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim is null)
                throw new Exception();

            var user = await _sqlContext.Users.Where(x => x.Id == Guid.Parse(userIdClaim.Value)).FirstOrDefaultAsync();

            return user is null ? throw new Exception() : user;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _sqlContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new Exception();

            return CreateToken(user);
        }

        public async Task Register(User user)
        {
            var userToCreate = new User
            {
                Id = Guid.NewGuid(),
                Username = user.Username,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                CreatedAt = DateTime.UtcNow,
            };

            _sqlContext.Add(userToCreate);
            await _sqlContext.SaveChangesAsync();

            return;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Token"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
