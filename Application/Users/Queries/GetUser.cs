using Domain.Models;
using MediatR;

namespace Application.Users.Queries
{
    public class GetUser : IRequest<User>
    {
        public string Id { get; set; } = string.Empty;
    }
}
