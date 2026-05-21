namespace Academy.API.Minimal.Endpoints;

public static class CategoryEndpoints
{
    public static void RegistraEndpointCategorie(this WebApplication webApplication)
    {
        var group = webApplication.MapGroup("/categorie");

        group.MapGet("/", GetAll())
         .WithDescription("Descrizione random")
         .WithSummary("Restituisce tutte le categorie")
         .WithName("GetCategorie")
        .Produces<List<CategoriaDTO>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);

        group.MapGet("/{id:int}", async (int id, IDatiCategorie datiCategorie) =>
        {
            if (id < 0) return Results.BadRequest();
            var categoria = await datiCategorie.EstraiPerIdAsync(id);
            if (categoria is null)
                return Results.NotFound();
            return Results.Ok(categoria);
        })
        .Produces<CategoriaDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError); ;


        group.MapPost("/", async (CategoriaCreaDTO categoria, IDatiCategorie datiCategorie) =>
        {
            if (categoria == null) { return Results.BadRequest(); }
            var cat = await datiCategorie.CreaCategoriaAsync(categoria);
            if (cat is null) return Results.NotFound();
            return Results.Created($"/categorie/{cat.CategoryId}", cat);
        })
        .Produces<CategoriaDTO>(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError)
        .Produces(StatusCodes.Status201Created); ;

        group.MapPatch("/{id:int}", async (int id, CategoriaAggiornaDTO categoria, IDatiCategorie datiCategorie) =>
        {
            if (id != categoria.Id) { return Results.BadRequest(); }
            if (categoria == null) { return Results.BadRequest(); }
            await datiCategorie.ModificaCategoriaAsync(categoria);
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, IDatiCategorie datiCategorie) =>
        {
            if (id < 0) { return Results.BadRequest(); }
            var boolean = await datiCategorie.CancellaPerId(id);
            if (boolean == false)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        });

    }

    private static Func<IDatiCategorie, Task<IResult>> GetAll()
    {
        return async (IDatiCategorie datiCategorie) =>
        {
            var categorie = await datiCategorie.EstraiTutteAsync();
            if (categorie is null)
                return Results.NotFound();
            return Results.Ok(categorie);
        };
    }
}
