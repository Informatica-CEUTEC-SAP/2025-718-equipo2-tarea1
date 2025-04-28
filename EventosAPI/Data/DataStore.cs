using EventosAPI.Models;

namespace EventosAPI.Data;

public static class DataStore
{
    public static List<Evento> Eventos { get; set; } = new()
    {
        new Evento { Id = 1, Nombre = "Concierto", Categoria = "Música", Ciudad = "San Pedro Sula", Fecha = DateTime.Now.AddDays(10) },
        new Evento { Id = 2, Nombre = "Noche Benefica", Categoria = "Comida", Ciudad = "Lempira", Fecha = DateTime.Now.AddDays(20) }
    };
}