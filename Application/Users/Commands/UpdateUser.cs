using Domain.Models;
using MediatR;

namespace Application.Users.Commands
{
    public class UpdateUser : IRequest<User>
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
