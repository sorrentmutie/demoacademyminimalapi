namespace demoacademyminimalapi.Extensions;

public static class ApplicationExtensions
{
    public static void RegistraServizi(this IServiceCollection services, string? connectionString)
    {
        services.AddOpenApi();
        services.AddScoped<IDatiCategorie, ServizioDatiCategorie>();
        services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));

    }
}
