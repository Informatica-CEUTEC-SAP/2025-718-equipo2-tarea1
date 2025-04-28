using EventosAPI.Data;
using EventosAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/eventos")]
public class EventosController : ControllerBase
{
    [HttpGet]
    public IActionResult GetEventos() => Ok(DataStore.Eventos);

    [HttpGet("{id}")]
    public IActionResult GetEvento(int id)
    {
        var evento = DataStore.Eventos.FirstOrDefault(e => e.Id == id);
        return evento is not null ? Ok(evento) : NotFound();
    }

    [HttpPost]
    public IActionResult CrearEvento(Evento evento)
    {
        DataStore.Eventos.Add(evento);
        return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento);
    }

    [HttpPut("{id}")]
    public IActionResult EditarEvento(int id, Evento evento)
    {
        var existente = DataStore.Eventos.FirstOrDefault(e => e.Id == id);
        if (existente is null) return NotFound();

        existente.Nombre = evento.Nombre;
        existente.Categoria = evento.Categoria;
        existente.Ciudad = evento.Ciudad;
        existente.Fecha = evento.Fecha;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarEvento(int id)
    {
        var evento = DataStore.Eventos.FirstOrDefault(e => e.Id == id);
        if (evento is null) return NotFound();

        DataStore.Eventos.Remove(evento);
        return NoContent();
    }

    [HttpGet("categoria/{nombre}")]
    public IActionResult FiltrarPorCategoria(string nombre) =>
        Ok(DataStore.Eventos.Where(e => e.Categoria == nombre));

    [HttpGet("ciudad/{nombre}")]
    public IActionResult FiltrarPorCiudad(string nombre) =>
        Ok(DataStore.Eventos.Where(e => e.Ciudad == nombre));

    [HttpGet("fecha")]
    public IActionResult FiltrarPorFechas([FromQuery] DateTime desde, [FromQuery] DateTime hasta) =>
        Ok(DataStore.Eventos.Where(e => e.Fecha >= desde && e.Fecha <= hasta));
}