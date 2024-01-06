using Application.Abstractions;
using Application.Users.Queries;
using Domain.Models;
using MediatR;

namespace Application.Users.QueryHandlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUsers, ICollection<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAll();
        }
    }
}
