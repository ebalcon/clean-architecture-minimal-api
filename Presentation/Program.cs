using Presentation.Endpoints;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.RegisterUserEndpoints();
app.RegisterAuthEndpoints();

app.Run();
