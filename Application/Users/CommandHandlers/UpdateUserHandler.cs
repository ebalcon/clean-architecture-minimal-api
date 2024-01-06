using Application.Abstractions;
using Application.Users.Commands;
using Domain.Models;
using MediatR;

namespace Application.Users.CommandHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var currentUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            };

            var user = await _userRepository.Update(currentUser, request.Id);
            return user;
        }
    }
}
