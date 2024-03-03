using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.BuscarPedidosPorStatus;
using LanchoneteDaRua.Ms.Pedidos.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace LanchoneteDaRua.Ms.Pedidos.Tests.Api.BuscarFilaDePedidos;

[Binding]
public class BuscarPedidosNaFilaSteps : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public BuscarPedidosNaFilaSteps(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [When(@"eu faço uma requisição de lista GET para '(.*)'")]
    public async Task QuandoEuFacoUmaRequisicaoGETPara(string url)
    {
        _response = await _client.GetAsync(url);
    }
    
    [Then(@"eu recebo uma resposta de lista com status (.*)")]
    public void EntaoEuReceboUmaRespostaComOStatus(int status)
    {
        Assert.Equal(status, (int)_response.StatusCode);
    }

    [Then(@"a resposta contém a lista de pedidos na fila")]
    public async Task EntaoARespostaContemAListaDePedidosNaFila()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var pedidos = JsonConvert.DeserializeObject<BuscarPedidosPorStatusOutput>(content);

        Assert.NotEmpty(pedidos.Pedidos);
    }

    [Then(@"a resposta indica que não há pedidos pendentes")]
    public async Task EntaoARespostaIndicaQueNaoHaPedidosPendentes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var pedidos = JsonConvert.DeserializeObject<BuscarPedidosPorStatusOutput>(content);

        Assert.NotEmpty(pedidos.Pedidos);
    }
}