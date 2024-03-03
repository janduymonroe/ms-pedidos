using System.Net;
using System.Net.Http.Json;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido;
using LanchoneteDaRua.Ms.Pedidos.Tests.Shared.Mocks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace LanchoneteDaRua.Ms.Pedidos.Tests.Api.CriarPedido;

[Binding]
public class CriarPedidoSteps : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private CriarPedidoInput _pedido;

    public CriarPedidoSteps(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Given(@"que eu tenho um pedido válido para criar")]
    public void DadoQueEuTenhoUmPedidoValidoParaCriar()
    {
        _pedido = PedidoMock.PedidoInputFake();
    }
    
    
    [Given(@"que eu tenho um pedido inválido para criar")]
    public void DadoQueEuTenhoUmPedidoInvalidoParaCriar()
    {
        _pedido = new CriarPedidoInput();
    }

    [When(@"eu envio uma solicitação POST para ""(.*)""")]
    public async Task QuandoEuEnvioUmaSolicitacaoPOSTPara(string url)
    {
        _response = await _client.PostAsJsonAsync(url, _pedido);
    }

    [Then(@"eu recebo uma resposta com o código de status (.*)")]
    public void EntaoEuReceboUmaRespostaComOCodigoDeStatus(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
    }

    [Then(@"o pedido é criado com sucesso")]
    public async Task EntaoOPedidoECriadoComSucesso()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var output = JsonConvert.DeserializeObject<CriarPedidoOutput>(content);

        Assert.False(output.HasError);
        Assert.Equal(_response.StatusCode, HttpStatusCode.Accepted);
    }
    
    [Then(@"o pedido input não é válido")]
    public async Task EntaoOPedidoNaoECriado()
    {
        var content = await _response.Content.ReadAsStringAsync();
        
        Assert.Equal(_response.StatusCode, HttpStatusCode.BadRequest);
    }
    
}