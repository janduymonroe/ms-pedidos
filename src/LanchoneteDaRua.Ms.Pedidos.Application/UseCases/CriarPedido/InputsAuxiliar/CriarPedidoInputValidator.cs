using FluentValidation;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido.InputsAuxiliar;

public class CriarPedidoInputValidator : AbstractValidator<CriarPedidoInput>
{
    public CriarPedidoInputValidator()
    {
        RuleFor(pedido => pedido.Cliente).NotNull().SetValidator(new ClienteInputValidator());
        RuleFor(pedido => pedido.InformacaoDePagamento).NotNull().SetValidator(new InformacaoDePagamentoInputValidator());
        RuleForEach(pedido => pedido.PedidoItems).NotNull().NotEmpty().SetValidator(new PedidoItemInputValidator());
    }
}