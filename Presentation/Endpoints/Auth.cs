using Application.Auth.Commands;
using Application.Auth.Queries;
using Application.Users.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation.Endpoints
{
    public static class Auth
    {
        public static void RegisterAuthEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup("/api/auth");

            users.MapPost("", Register)
                .WithName("register")
                .WithTags("User")
                .WithSummary("Register (create) a new user.")
                .AllowAnonymous();

            users.MapPost("/login", Login)
                .WithName("login")
                .WithTags("Auth")
                .WithSummary("Login with email and password.")
                .AllowAnonymous();

            users.MapGet("", GetCurrent)
                .WithName("getCurrent")
                .WithTags("Auth")
                .WithSummary("Get the current user.");
        }

        private static async Task<IResult> Register(IMediator mediator, RegisterAuth user)
        {
            await mediator.Send(user);
            return Results.Ok();
        }

        private static async Task<IResult> Login(IMediator mediator, LoginAuth user)
        {
            var token = await mediator.Send(user);
            return Results.Ok(token);
        }

        private static async Task<IResult> GetCurrent(IMediator mediator)
        {
            var currentUser = await mediator.Send(new GetCurrentAuth { });
            return Results.Ok(currentUser);
        }
    }
}
