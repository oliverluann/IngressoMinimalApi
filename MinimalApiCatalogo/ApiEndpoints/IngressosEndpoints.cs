using Microsoft.EntityFrameworkCore;
using MinimalApiCatalogo.Context;
using MinimalApiCatalogo.Models;

namespace IngressoMinimalApi.ApiEndpoints
{
    public static class IngressosEndpoints
    {
        public static void MapIngressosEndpoints(this WebApplication app)
        {
            app.MapPost("/ingresso", async (Ingresso ingresso, AppDbContext db) =>
            {
                db.Ingresso.Add(ingresso);
                await db.SaveChangesAsync();

                return Results.Created($"/ingresso/{ingresso.IngressoId}", ingresso);

            });

            //Endpoint protegido com RequireAuthorization.
            app.MapGet("/ingresso", async (AppDbContext db) =>
                await db.Ingresso.ToArrayAsync()).WithTags("Ingresso").RequireAuthorization();

            app.MapGet("/ingresso/{id:int}", async (int id, AppDbContext db) =>
            {
                return await db.Ingresso.FindAsync(id)
                             is Ingresso ingresso
                             ? Results.Ok(ingresso)
                             : Results.NotFound();
            });

            app.MapPut("/ingresso/{id:int}", async (int id, Ingresso ingresso, AppDbContext db) =>

            {

                if (ingresso.IngressoId != id)
                {
                    return Results.BadRequest();
                }

                var ingressoDB = await db.Ingresso.FindAsync(id);
                if (ingressoDB is null) return Results.NotFound("Id/Produto não encontrado!");

                ingressoDB.Nome = ingresso.Nome;
                ingressoDB.Descricao = ingresso.Descricao;
                ingressoDB.Preco = ingresso.Preco;
                ingressoDB.Imagem = ingresso.Imagem;
                ingressoDB.DataCompra = ingresso.DataCompra;
                ingressoDB.Estoque = ingresso.Estoque;
                ingressoDB.CategoriaId = ingresso.CategoriaId;

                await db.SaveChangesAsync();

                return Results.Ok(ingressoDB);

            });

            app.MapDelete("/ingresso/{id:int}", async (int id, AppDbContext db) =>
            {
                var ingresso = await db.Ingresso.FindAsync(id);

                if (ingresso is null)
                {
                    return Results.NotFound();
                }

                db.Ingresso.Remove(ingresso);
                await db.SaveChangesAsync();

                return Results.NoContent();

            });
        }
    }
}
