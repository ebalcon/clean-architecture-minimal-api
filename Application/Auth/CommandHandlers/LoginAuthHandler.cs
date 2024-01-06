using Application.Abstractions;
using Application.Auth.Commands;
using MediatR;

namespace Application.Auth.CommandHandlers
{
    public class LoginAuthHandler : IRequestHandler<LoginAuth, string>
    {
        private readonly IAuthRepository _authRepository;

        public LoginAuthHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<string> Handle(LoginAuth request, CancellationToken cancellationToken)
        {
            return await _authRepository.Login(request.Email, request.Password); ;
        }
    }
}
