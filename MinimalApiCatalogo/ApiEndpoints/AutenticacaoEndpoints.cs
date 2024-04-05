using Microsoft.AspNetCore.Authorization;
using MinimalApiCatalogo.Models;
using MinimalApiCatalogo.Services;

namespace IngressoMinimalApi.ApiEndpoints
{
    public static class AutenticacaoEndpoints
    {
        public static void MapAutenticacaoEndpoints(this WebApplication app)
        {
            //Endpoint para login.
            app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ItokenService tokenService) =>
            {
                if (userModel == null)
                {
                    return Results.BadRequest("Login Inválido");
                }
                if (userModel.UserName == "luan" && userModel.Password == "token1428#")
                {
                    var tokenString = tokenService.GetToken(app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"],
                        userModel);
                    return Results.Ok(new { token = tokenString });
                }
                else
                {
                    return Results.BadRequest("Login Inválido");
                }
            }).Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status200OK)
                .WithName("Login")
                .WithTags("Autenticacao");
        }

    }
}
