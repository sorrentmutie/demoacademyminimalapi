
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

app.MapGet("/{id:int}", async (int id, IDatiCategorie datiCategorie) =>
{
    if(id <0) return Results.BadRequest();
    var categoria = await datiCategorie.EstraiPerIdAsync(id);
    if (categoria is null)
        return Results.NotFound();
    return Results.Ok(categoria);
})
.Produces<CategoriaDTO>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status500InternalServerError); ;




app.UseHttpsRedirection();

app.Run();
