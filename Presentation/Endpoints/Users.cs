using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;

namespace Presentation.Endpoints
{
    public static class Users
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup("/api/users");

            users.MapGet("", GetAll).WithName("getAll")
                .WithTags("User")
                .WithSummary("Get all the users.");

            users.MapGet("/{id}", GetOne).WithName("getOne")
                .WithTags("User")
                .WithSummary("Get one user by is Id.");

            users.MapDelete("/{id}", Delete).WithName("delete")
                .WithTags("User")
                .WithSummary("Delete user by is Id.");
        }

        private static async Task<IResult> GetAll(IMediator mediator)
        {
            var users = await mediator.Send(new GetAllUsers {});
            return Results.Ok(users);
        }

        private static async Task<IResult> GetOne(IMediator mediator, string id)
        {
            var user = await mediator.Send(new GetUser { Id = id });
            return Results.Ok(user);
        }

        private static async Task<IResult> Delete(IMediator mediator, string id)
        {
            await mediator.Send(new DeleteUser { Id = id });
            return Results.Ok();
        }
    }
}
