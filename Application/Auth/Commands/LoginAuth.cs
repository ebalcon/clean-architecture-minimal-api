using MediatR;

namespace Application.Auth.Commands
{
    public class LoginAuth : IRequest<string>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
