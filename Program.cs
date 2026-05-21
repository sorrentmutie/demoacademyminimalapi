var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDatiCategorie, ServizioDatiCategorie>();
builder.Services.AddDbContext<NorthwindContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/categorie", async (IDatiCategorie datiCateogrie) =>
{
    var categorie = await datiCateogrie.EstraiTutteAsync();
    if (categorie is null)
        return Results.NotFound();
    return Results.Ok(categorie);
});

app.UseHttpsRedirection();

app.Run();