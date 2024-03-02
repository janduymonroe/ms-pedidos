using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.BuscarPedidosPorStatus;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido;
using LanchoneteDaRua.Ms.Pedidos.Domain.Entities;
using LanchoneteDaRua.Ms.Pedidos.Domain.Enums;
using LanchoneteDaRua.Ms.Pedidos.Tests.Shared.Mocks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace LanchoneteDaRua.Ms.Pedidos.Tests.Api.AtualizarStatusPedido;

[Binding]
public sealed class AtualizarStatusPedidoSteps : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private CriarPedidoInput _pedido;
    private Guid _id;

    public AtualizarStatusPedidoSteps(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    
    [Given(@"que eu tenho um pedido criado")]
    public void DadoQueEuTenhoUmPedidoExistenteComOID()
    {
        _pedido = PedidoMock.PedidoInputFake();
        var response = _client.PostAsJsonAsync("api/v1/pedidos", _pedido).Result;
        var pedido = JsonConvert.DeserializeObject<CriarPedidoOutput>(response.Content.ReadAsStringAsync().Result);
        _id = pedido.Id;
    }
    
    [When(@"eu faço uma requisição PATCH para '(.*)'")]
    public async Task QuandoEuFacoUmaRequisicaoPATCHPara(string url)
    {
        var urlRequest = url.Replace("{id}", _id.ToString());
        var content = new StringContent(JsonConvert.SerializeObject(new ()),Encoding.UTF8, "application/json");
        _response = await _client.PatchAsync(urlRequest, content);
    }

    [Then(@"eu recebo uma resposta com status (.*)")]
    public void EntaoEuReceboUmaRespostaComOStatus(int status)
    {
        Assert.Equal(status, (int)_response.StatusCode);
    }

    [Then(@"a resposta confirma que o status do pedido foi atualizado para '(.*)'")]
    public async Task EntaoARespostaConfirmaQueOStatusDoPedidoFoiAtualizadoPara(int status)
    {
        Assert.Equal(status, (int)_response.StatusCode);
    }
}