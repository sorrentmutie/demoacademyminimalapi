using Microsoft.EntityFrameworkCore.Storage;

namespace demoacademyminimalapi.EndPoints;

public static class CategoryEndpoints
{
    public static async Task RegistraEndpointCategorie(this WebApplication webApplication)
    {
        var group = webApplication.MapGroup("/categorie");
        group.MapGet("/", async (IDatiCategorie datiCateogrie) =>
        {
            var categorie = await datiCateogrie.EstraiTutteAsync();
            if (categorie is null)
                return Results.NotFound();
            return Results.Ok(categorie);
        })
        .Produces<List<CategoriaDTO>>(StatusCodes.Status200OK)
        .Produces<CategoriaDTO>(StatusCodes.Status404NotFound)
        .Produces<CategoriaDTO>(StatusCodes.Status500InternalServerError)
        .WithDescription("")
        .WithName("GetCategorie")
        .WithSummary("Restitiuisce tutte le categorie");

        group.MapGet("/{id:int}", async (int id, IDatiCategorie categorie) =>
        {
            if (id < 0) return Results.BadRequest();
            var categoria = await categorie.EstraiPerIdAsync(id);
            if (categoria is null) return Results.NotFound();
            return Results.Ok(categoria);
        }).Produces<CategoriaDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError);

        group.MapPost("/", async (CategoriaCreaDTO categoria, IDatiCategorie datiCategorie) =>
        {
            var cat = await datiCategorie.CreaCategoriaAsync(categoria);
            if (cat is null) return Results.NotFound();
            return Results.Created($"/categorie/{cat.CategoryId}", cat);
        }).Produces<CategoriaDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError)
        .Produces(StatusCodes.Status201Created);

        group.MapPatch("/{id:int}",async(int id,CategoriaAggiornaDTO categoria, IDatiCategorie datiCategorie) =>
        {
            if(id !=categoria.Id) return Results.BadRequest();
            if (categoria == null) return Results.BadRequest();
            await datiCategorie.ModificaCategoriaAsync(categoria);
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id,IDatiCategorie datiCategorie) =>
        {
            if (id<0) return Results.BadRequest();
            var boolean = await datiCategorie.CancellaPerId(id);
            if(boolean == false) return Results.NotFound();
            return Results.NoContent();
        });
    }

}
