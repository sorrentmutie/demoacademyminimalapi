namespace demoacademyminimalapi.dtos;

public record CategoriaDTO(int Id, string Nome, string Descrizione, int NumeroProdotti);

public record CategoriaCreaDTO(string Nome, string Descrizione);

public record CategoriaAggiornaDTO(int Id, string Nome, string Descrizione);

