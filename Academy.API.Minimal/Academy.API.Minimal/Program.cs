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

app.RegistraEndpointCategorie();

app.UseHttpsRedirection();

app.Run();
