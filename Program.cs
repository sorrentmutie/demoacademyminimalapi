var builder = WebApplication.CreateBuilder(args);
builder.Services.RegistraServizi(builder.Configuration.GetConnectionString("NorthwindContext"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.RegistraEndpointCategorie();

app.UseHttpsRedirection();

app.Run();