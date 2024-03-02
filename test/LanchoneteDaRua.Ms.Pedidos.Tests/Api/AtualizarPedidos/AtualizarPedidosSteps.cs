using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.AtualizarPedido;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido;
using LanchoneteDaRua.Ms.Pedidos.Domain.Entities;
using LanchoneteDaRua.Ms.Pedidos.Tests.Shared.Mocks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace LanchoneteDaRua.Ms.Pedidos.Tests.Api.AtualizarPedidos;

[Binding]
public class AtualizarPedidoSteps : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private CriarPedidoInput _pedido;
    private AtualizarPedidoInput _atualizarPedidoInput;
    private Guid _id;

    public AtualizarPedidoSteps(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    
    [Given(@"que eu tenho um pedido já criado com ID")]
    public void DadoQueEuTenhoUmPedidoExistenteComOID()
    {
        _pedido = PedidoMock.PedidoInputFake();
        var response = _client.PostAsJsonAsync("api/v1/pedidos", _pedido).Result;
        var pedido = JsonConvert.DeserializeObject<CriarPedidoOutput>(response.Content.ReadAsStringAsync().Result);
        _id = pedido.Id;
    }
    
    [When(@"eu faço uma requisição PUT para '(.*)'")]
    public async Task QuandoEuFacoUmaRequisicaoPUTPara(string url)
    {
        var novosDados = PedidoMock.AtualizarPedidoInputFake(_id);
        var urlRequest = url.Replace("{id}", _id.ToString());
        _response = await _client.PutAsJsonAsync(urlRequest, novosDados);
    }
    
    [Then(@"eu recebo uma resposta de atualização com status (.*)")]
    public void EntaoEuReceboUmaRespostaComOStatus(int status)
    {
        Assert.Equal(status, (int)_response.StatusCode);
    }

    [Then(@"a resposta confirma que o pedido foi atualizado")]
    public async Task EntaoARespostaConfirmaQueOPedidoFoiAtualizado()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var pedido = JsonConvert.DeserializeObject<AtualizarPedidoOutput>(content);

        Assert.NotNull(pedido);
    }
}