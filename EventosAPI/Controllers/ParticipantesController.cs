using EventosAPI.Data;
using EventosAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/eventos/{id}/participantes")]
public class ParticipantesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetParticipantes(int id)
    {
        var evento = DataStore.Eventos.FirstOrDefault(e => e.Id == id);
        return evento is not null ? Ok(evento.Participantes) : NotFound();
    }

    [HttpPost]
    public IActionResult AddParticipante(int id, Participante participante)
    {
        var evento = DataStore.Eventos.FirstOrDefault(e => e.Id == id);
        if (evento is null) return NotFound();
        evento.Participantes.Add(participante);
        return CreatedAtAction(nameof(GetParticipantes), new { id }, participante);
    }

    [HttpDelete("{dni}")]
    public IActionResult DeleteParticipante(int id, string dni)
    {
        var evento = DataStore.Eventos.FirstOrDefault(e => e.Id == id);
        if (evento is null) return NotFound();

        var participante = evento.Participantes.FirstOrDefault(p => p.Dni == dni);
        if (participante is null) return NotFound();

        evento.Participantes.Remove(participante);
        return NoContent();
    }
}