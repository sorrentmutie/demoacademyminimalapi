namespace Academy.API.Minimal.Services;

public class ServizioDatiCategorie : IDatiCategorie
{
    private readonly NorthwindContext database;

    public ServizioDatiCategorie(NorthwindContext database)
    {
        this.database = database;
    }

    public async Task<bool> CancellaPerId(int id)
    {
        var catOnDb = await database.Categories.FindAsync(id);
        if (catOnDb == null) return false;
        database.Categories.Remove(catOnDb);
        await database.SaveChangesAsync();
        return true;
    }

    public async Task<Category?> CreaCategoriaAsync(CategoriaCreaDTO categoria)
    {
        var cat = categoria.FromDTO();
        if (cat == null) return null;
        database.Categories.Add(cat);
        await database.SaveChangesAsync();
        return cat;
    }

    public async Task<CategoriaDTO?> EstraiPerIdAsync(int id)
    {
        var c = await database.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == id);

        if (c == null) return null;
        return c.ToDTO();
     }

    public async Task<IEnumerable<CategoriaDTO>?> EstraiTutteAsync()
    {
       return await database.Categories.Include(c => c.Products)
            .Select(c => new CategoriaDTO
            (  c.CategoryId ,
               c.CategoryName,
               c.Description,
               c.Products.Count
            ))
            .ToListAsync();
    }

    public async Task ModificaCategoriaAsync(CategoriaAggiornaDTO categoria)
    {

        var catOnDb = await database.Categories.FindAsync(categoria.Id);
        if (catOnDb == null) return;
        
        if (!string.IsNullOrEmpty(categoria.Nome))
        {
            catOnDb.CategoryName = categoria.Nome;
        }
        if (!string.IsNullOrEmpty(categoria.Descrizione))
        {
            catOnDb.Description = categoria.Descrizione;
        }
        await database.SaveChangesAsync();

    }
}
