using Application.Abstractions;
using Application.Auth.Queries;
using Domain.Models;
using MediatR;

namespace Application.Auth.QueryHandlers
{
    public class GetCurrentAuthHandler : IRequestHandler<GetCurrentAuth, User>
    {
        private readonly IAuthRepository _authRepository;

        public GetCurrentAuthHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> Handle(GetCurrentAuth request, CancellationToken cancellationToken)
        {
            var user = await _authRepository.GetCurrent();
            return user;
        }
    }
}
