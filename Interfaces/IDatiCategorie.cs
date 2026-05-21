namespace demoacademyminimalapi.interfaces;

public interface IDatiCategorie
{
    Task<IEnumerable<CategoriaDTO>?> EstraiTutteAsync();
    Task<Category?> CreaCategoriaAsync(CategoriaCreaDTO categoria);
    Task ModificaCategoriaAsync(CategoriaAggiornaDTO categoria);
    Task<CategoriaDTO?> EstraiPerIdAsync(int id);

    Task<bool> CancellaPerId(int id);  
    
    
}