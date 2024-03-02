using FluentValidation;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.AtualizarPedido;

public class AtualizarPedidoInputValidator : AbstractValidator<AtualizarPedidoInput>
{
    public AtualizarPedidoInputValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}