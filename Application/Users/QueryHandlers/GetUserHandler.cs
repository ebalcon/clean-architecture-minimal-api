using Application.Abstractions;
using Application.Users.Queries;
using Domain.Models;
using MediatR;

namespace Application.Users.QueryHandlers
{
    public class GetUserHandler : IRequestHandler<GetUser, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUser request, CancellationToken cancellationToken)
        {
            return await _userRepository.Get(request.Id);
        }
    }
}
