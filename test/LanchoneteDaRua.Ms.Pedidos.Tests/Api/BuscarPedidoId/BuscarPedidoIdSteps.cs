using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.BuscarPedidoPorId;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido;
using LanchoneteDaRua.Ms.Pedidos.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace LanchoneteDaRua.Ms.Pedidos.Tests.Api.BuscarPedidoId;

[Binding]
public class BuscarPedidoPorIdSteps : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private CriarPedidoInput _pedido;

    public BuscarPedidoPorIdSteps(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Given(@"que eu tenho um pedido existente com o ID '(.*)'")]
    public void DadoQueEuTenhoUmPedidoExistenteComOID(Guid id)
    {
        // Configurar um pedido de testes caso preciso
    }

    [Given(@"que eu não tenho um pedido com o ID '(.*)'")]
    public void DadoQueEuNaoTenhoUmPedidoComOID(Guid id)
    {
        // Configurar um pedido de testes caso preciso
    }

    [When(@"eu faço uma requisição GET para '(.*)'")]
    public async Task QuandoEuFacoUmaRequisicaoGETPara(string url)
    {
        _response = await _client.GetAsync(url);
    }

    [Then(@"eu recebo uma resposta com o status (.*)")]
    public void EntaoEuReceboUmaRespostaComOStatus(int status)
    {
        Assert.Equal(status, (int)_response.StatusCode);
    }

    [Then(@"a resposta contém as informações do pedido com o ID '(.*)'")]
    public async Task EntaoARespostaContemAsInformacoesDoPedidoComOID(Guid id)
    {
        var content = await _response.Content.ReadAsStringAsync();
        var pedido = JsonConvert.DeserializeObject<BuscarPedidoPorIdOutput>(content);

        Assert.Equal(id, pedido.Id);
    }
}