var builder = WebApplication.CreateBuilder(args);
builder.Services.RegistraServizi(builder.Configuration.GetConnectionString("NorthwindContext"));
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

var group = app.MapGroup("/categorie");
group.MapGet("/", async (IDatiCategorie datiCateogrie) =>
{
    var categorie = await datiCateogrie.EstraiTutteAsync();
    if (categorie is null)
        return Results.NotFound();
    return Results.Ok(categorie);
})
.Produces<List<CategoriaDTO>>(StatusCodes.Status200OK)
.Produces<CategoriaDTO>(StatusCodes.Status404NotFound)
.Produces<CategoriaDTO>(StatusCodes.Status500InternalServerError);

group.MapGet("/{id:int}", async (int id, IDatiCategorie categorie) =>
{
    if(id<0) return Results.BadRequest();
    var categoria = await categorie.EstraiPerIdAsync(id);
    if (categoria is null) return Results.NotFound();
    return Results.Ok(categoria);
});

app.UseHttpsRedirection();

app.Run();