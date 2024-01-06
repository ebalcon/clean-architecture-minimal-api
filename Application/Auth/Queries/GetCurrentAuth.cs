using Domain.Models;
using MediatR;

namespace Application.Auth.Queries
{
    public class GetCurrentAuth : IRequest<User>
    {
    }
}
