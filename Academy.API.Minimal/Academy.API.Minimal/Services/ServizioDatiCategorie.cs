namespace Academy.API.Minimal.Services;

public class ServizioDatiCategorie : IDatiCategorie
{
    public Task CreaCategoriaAsync(CategoriaCreaDTO categoria)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoriaDTO>?> EstraiTutteAsync()
    {
        throw new NotImplementedException();
    }

    public Task ModificaCategoriaAsync(CategoriaAggiornaDTO categoria)
    {
        throw new NotImplementedException();
    }
}
