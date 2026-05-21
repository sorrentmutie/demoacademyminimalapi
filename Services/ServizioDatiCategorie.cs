namespace demoacademyminimalapi.services;

public class ServizioDatiCategorie : IDatiCategorie
{
    private readonly NorthwindContext database;
    public ServizioDatiCategorie(NorthwindContext database)
    {
        this.database = database;
    }

    public Task CreaCategoriaAsync(CategoriaCreaDTO categoria)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoriaDTO>?> EstraiTutteAsync()
    {
        return await database.Categories.Include(c => c.Products)
            .Select(c => new CategoriaDTO (
                c.CategoryId,
                c.CategoryName,
                c.Description,
                c.Products.Count
                )).ToListAsync();
    }

    public Task ModificaCategoriaAsync(CategoriaAggiornaDTO categoria)
    {
        throw new NotImplementedException();
    }
}