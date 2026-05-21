namespace Academy.API.Minimal.Endpoints;

public static class CategoryEndpoints
{
    public static void RegistraEndpointCategorie(this WebApplication webApplication) {
        var group = webApplication.MapGroup("/categorie");

        group.MapGet("/", async (IDatiCategorie datiCategorie) =>
        {
            var categorie = await datiCategorie.EstraiTutteAsync();
            if (categorie is null)
                return Results.NotFound();
            return Results.Ok(categorie);
        })
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

    }
}
