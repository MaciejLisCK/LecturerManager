using LecturerManager.Application.Features.Identity.Commands.LoginStudent;
using LecturerManager.Application.Features.Identity.Commands.RegisterStudent;
using MediatR;

namespace LecturerManager.Api.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/auth/public-key", (IConfiguration configuration) =>
        {
            var publicKey = configuration["Rsa:PublicKey"];
            if (string.IsNullOrWhiteSpace(publicKey))
                return Results.Problem("RSA public key is not configured.");
            return Results.Ok(new { publicKey });
        })
        .WithName("GetPublicKey")
        .WithTags("Auth")
        .Produces<object>()
        .Produces(StatusCodes.Status500InternalServerError);

        app.MapPost("/auth/register", async (RegisterStudentCommand command, ISender sender, CancellationToken cancellationToken) =>
        {
            var id = await sender.Send(command, cancellationToken);
            return Results.Created($"/auth/register/{id}", new { id });
        })
        .WithName("RegisterStudent")
        .WithTags("Auth")
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapPost("/auth/login/student", async (LoginStudentCommand command, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(command, cancellationToken);
            return Results.Ok(response);
        })
        .WithName("LoginStudent")
        .WithTags("Auth")
        .Produces<LoginStudentResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status401Unauthorized);

        return app;
    }
}
