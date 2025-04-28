namespace EventosAPI.Models;

public class Evento
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Categoria { get; set; }
    public required string Ciudad { get; set; }
    public DateTime Fecha { get; set; }
    public List<Participante> Participantes { get; set; } = new();
}