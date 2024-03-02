using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido.InputsAuxiliar;
using LanchoneteDaRua.Ms.Pedidos.Domain.ValueObjects;

namespace LanchoneteDaRua.Ms.Pedidos.Tests.Shared.Mocks;

public static class InformacaoDePagamentoMock
{
    private static readonly string NomeCompleto = "Joao Testador";
    private static readonly string NumeroDoCartao = "4179873502570929";
    private static readonly string DataExpiracao = "05/34";
    private static readonly string Cvv = "210";

    public static InformacaoDePagamento InformacaoDePagamentoFake()
    {
        return new InformacaoDePagamento(NumeroDoCartao, NomeCompleto, DataExpiracao, Cvv);
    }

    public static InformacaoDePagamentoInput InformacaoDePagamentoInputFaker()
    {
        return new InformacaoDePagamentoInput
        {
            NomeCompleto = NomeCompleto,
            NumeroDoCartao = NumeroDoCartao,
            DataExpiracao = DataExpiracao,
            Cvv = Cvv
        };
    }
}