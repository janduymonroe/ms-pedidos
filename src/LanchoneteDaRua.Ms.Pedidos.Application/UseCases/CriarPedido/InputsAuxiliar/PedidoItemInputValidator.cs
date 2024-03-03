using FluentValidation;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido.InputsAuxiliar;

public class PedidoItemInputValidator : AbstractValidator<PedidoItemInput>
{
    public PedidoItemInputValidator()
    {
        RuleFor(pedidoItem => pedidoItem.IdProduto)
            .NotEmpty();
        
        RuleFor(pedidoItem => pedidoItem.Quantidade)
            .GreaterThan(0);
        
        RuleFor(x => x.Preco)
            .GreaterThan(0);
        
    }
}