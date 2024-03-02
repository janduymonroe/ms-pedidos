using FluentValidation;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido.InputsAuxiliar;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido;

public class PedidoInputValidator : AbstractValidator<PedidoInput>
{
    public PedidoInputValidator()
    {
        RuleFor(pedido => pedido.Cliente).NotNull().SetValidator(new ClienteInputValidator());
        RuleFor(pedido => pedido.InformacaoDePagamento).NotNull().SetValidator(new InformacaoDePagamentoInputValidator());
        RuleForEach(pedido => pedido.PedidoItems).NotNull().NotEmpty().SetValidator(new PedidoItemInputValidator());
    }
}