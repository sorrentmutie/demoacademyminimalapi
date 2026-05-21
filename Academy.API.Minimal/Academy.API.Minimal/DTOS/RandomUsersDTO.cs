namespace Academy.API.Minimal.DTOS;

    public class RandomUsersDTO
    {

    public string NomeCompleto { get; set; }
    public Genere Genere { get; set; }
    public string linkFoto { get; set; }

}

public enum Genere
{
    Donna,
    Uomo,
    Altro
}