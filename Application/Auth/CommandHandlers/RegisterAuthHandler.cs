using Application.Abstractions;
using Application.Auth.Commands;
using Domain.Models;
using MediatR;

namespace Application.Auth.CommandHandlers
{
    public class RegisterAuthHandler : IRequestHandler<RegisterAuth>
    {
        private readonly IAuthRepository _authRepository;

        public RegisterAuthHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Unit> Handle(RegisterAuth request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
            };

            await _authRepository.Register(newUser);

            return Unit.Value;
        }
    }
}
