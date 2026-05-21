using System.ComponentModel.DataAnnotations;

namespace Academy.API.Minimal.DTOS;
public record CategoriaDTO(int Id, string Nome, string Descrizione, int NumeroProdotti);


public record CategoriaCreaDTO( string Nome, string Descrizione);

public record CategoriaAggiornaDTO(int Id, string Nome, string Descrizione);