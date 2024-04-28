using AgendaAPI.DTOs;
using AgendaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AgendaController : ControllerBase
{
    private readonly IAgendaService _agendaService;

    public AgendaController(IAgendaService agendaService)
    {
        _agendaService = agendaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var contato = await _agendaService.GetAll();

        if (contato.Any())
            return Ok(contato);

        return Ok("Não há nenhum contato cadastrado.");
    }

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetById(string nome)
    {
        var contato = await _agendaService.GetByName(nome);

        if (contato.Any())
            return Ok(contato);

        return Ok($"Não há nenhum contato cadastrado com o nome: {nome}.");
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContatoDTO contato)
    {
        var result = await _agendaService.Create(contato);

        if (result)
            return Ok("Usuário cadastrado com sucesso");

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(ContatoDTO contato)
    {
        var result = await _agendaService.Update(contato);

        if (result)
            return Ok($"O usuário {contato.Nome}({contato.Email}) foi atualizado com sucesso");

        return BadRequest("Não foi possível atualizar o usuário");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _agendaService.Delete(id);

        if (result)
            return Ok($"O usuário foi removido com sucesso");

        return BadRequest("Não foi possível remover o usuário");
    }
}

