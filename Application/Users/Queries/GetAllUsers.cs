using Domain.Models;
using MediatR;

namespace Application.Users.Queries
{
    public class GetAllUsers : IRequest<ICollection<User>>
    {
    }
}
