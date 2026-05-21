using Academy.API.Minimal.DTOS;

namespace Academy.API.Minimal.Interfaces;

public interface IDatiCategorie
{
    Task<IEnumerable<CategoriaDTO>?> EstraiTutteAsync();
    Task CreaCategoriaAsync(CategoriaCreaDTO categoria);
    Task ModificaCategoriaAsync(CategoriaAggiornaDTO categoria);
}
