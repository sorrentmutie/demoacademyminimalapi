namespace demoacademyminimalapi.interfaces;

public interface IDatiCategorie
{
    Task<IEnumerable<CategoriaDTO>?> EstraiTutteAsync();
    Task CreaCategoriaAsync(CategoriaCreaDTO categoria);
    Task ModificaCategoriaAsync(CategoriaAggiornaDTO categoria);
    Task<CategoriaDTO?> EstraiPerIdAsync(int id);
    
    
}