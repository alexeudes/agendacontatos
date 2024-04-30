using AgendaAPI.Controllers;
using AgendaAPI.Data;
using AgendaAPI.Data.Repositories;
using AgendaAPI.DTOs;
using AgendaAPI.Models;
using AgendaAPI.Services;
using AgendaAPI.Services.Interfaces;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AgendaAPI.Test;

public class AgendaTestController
{
    private AgendaController _agendacontroller;
    private IAgendaService _agendaService;

    public AgendaTestController(DataContext _context, IMapper _mapper)
    {
        _agendaService = new AgendaService(new AgendaRepository(_context), _mapper);
        _agendacontroller = new AgendaController(_agendaService);
    }

    [Fact]
    public async Task GetContato_Sucess()
    {
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.GetAll());
        var result = (OkObjectResult) await _agendacontroller.Get();
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetListaContatos()
    {
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.GetAll());
        var result = await _agendacontroller.Get();

        result.Should().BeOfType<OkObjectResult>();
        var resultList = (OkObjectResult)result;
        resultList.Value.Should().BeOfType<List<ContatoDTO>>();
    }

    [Fact]
    public async Task GetListaContatosSemCadastro()
    {
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.GetAll());
        var result = await _agendacontroller.Get();

        result.Should().BeOfType<OkObjectResult>();
        var resultList = (OkObjectResult)result;
        resultList.Value.Should().Be("Não há nenhum contato cadastrado.");
    }

    [Fact]
    public async Task GetById_Sucess()
    {
        var contato = new ContatoDTO{
            ID = 1,
            Nome = "Alex",
            Email = "alex@gmail.com",
            Telefone = "(81) 99999-9999",
        };
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.GetById(contato.ID.ToString())).ReturnsAsync(contato);
        var result = await _agendacontroller.GetById(contato.ID.ToString());

        result.Should().BeOfType<OkObjectResult>();
        var objResult = (OkObjectResult)result;
        objResult.StatusCode.Should().Be(200);
        objResult.Value.Should().BeOfType<ContatoDTO>();
    }

    [Fact]
    public async Task GetById_Error()
    {
        var contato = new ContatoDTO{};
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.GetById("1")).ReturnsAsync(contato);
        var result = await _agendacontroller.GetById("1");

        result.Should().BeOfType<NotFoundObjectResult>();
        var objResult = (NotFoundObjectResult)result;
        objResult.StatusCode.Should().Be(404);
        objResult.Value.Should().Be("Nenhum contato cadastrado para o ID informado.");
    }

    [Fact]
    public async Task Create_Sucess()
    {
        var contato = new ContatoDTO
        {
            ID = 1,
            Nome = "Alex",
            Email = "alex@gmail.com",
            Telefone = "(81) 99999-9999",
        };
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.Create(contato)).ReturnsAsync(true);
        var result = await _agendacontroller.Create(contato);

        result.Should().BeOfType<CreatedResult>();
        var createResult = (CreatedResult)result;
        createResult.StatusCode.Should().Be(201);
    }

    [Fact]
    public async Task Create_Error()
    {
        var contato = new ContatoDTO
        {
            ID = 1,
            Nome = "Alex",
            Email = "alex@gmail.com",
            Telefone = "(81) 99999-9999",
        };
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.Create(contato)).ReturnsAsync(false);
        var result = await _agendacontroller.Create(contato);

        result.Should().BeOfType<BadRequestResult>();
        var createResult = (BadRequestResult)result;
        createResult.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Update_Sucess()
    {
        var contato = new ContatoDTO
        {
            ID = 1,
            Nome = "Alex",
            Email = "alex@gmail.com",
            Telefone = "(81) 99999-9999",
        };
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.Update(contato)).ReturnsAsync(true);
        var result = (OkObjectResult)await _agendacontroller.Update(contato);
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_Error()
    {
        var contato = new ContatoDTO
        {
            ID = 1,
            Nome = "Alex",
            Email = "alex@gmail.com",
            Telefone = "(81) 99999-9999",
        };
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.Update(contato)).ReturnsAsync(false);
        var result = (BadRequestResult)await _agendacontroller.Update(contato);
        result.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Delete_Sucess()
    {
        int id = 1;
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.Delete(id)).ReturnsAsync(true);
        var result = (OkObjectResult)await _agendacontroller.Delete(id);
        result.Should().BeOfType<OkObjectResult>();
        var deleteResult = (OkObjectResult)result;
        deleteResult.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Delete_Error()
    {
        int id = 1;
        var mock = new Mock<IAgendaService>();
        mock.Setup(ms => ms.Delete(id)).ReturnsAsync(false);
        var result = (BadRequestObjectResult)await _agendacontroller.Delete(id);

        result.Should().BeOfType<BadRequestObjectResult>();
        var deleteResult = (BadRequestObjectResult)result;
        deleteResult.StatusCode.Should().Be(400);
    }
}
