using MediatR;

namespace Application.Users.Commands
{
    public class DeleteUser : IRequest
    {
        public string Id { get; set; } = string.Empty;
    }
}
