using Application.Abstractions;
using Application.Users.Commands;
using MediatR;

namespace Application.Users.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
