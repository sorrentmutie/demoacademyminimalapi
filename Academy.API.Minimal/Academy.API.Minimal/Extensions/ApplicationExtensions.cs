namespace Academy.API.Minimal.Extensions;

public static class ApplicationExtensions
{
    public static void RegistraServizi(this IServiceCollection services, string? connectionString)
    {
        services.AddOpenApi();
        services.AddScoped<IDatiCategorie, ServizioDatiCategorie>();
        services.AddDbContext<NorthwindContext>(
            options =>
            options.UseSqlServer(connectionString));

        services.AddHttpClient("RandomUser", client => {
            client.BaseAddress = new Uri("https://randomuser.me/api"); 
        });

    }
}
