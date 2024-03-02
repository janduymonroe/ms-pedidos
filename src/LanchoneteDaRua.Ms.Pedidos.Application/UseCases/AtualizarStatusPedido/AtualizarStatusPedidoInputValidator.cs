using FluentValidation;
using LanchoneteDaRua.Ms.Pedidos.Domain.Enums;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.AtualizarStatusPedido;

public class AtualizarStatusPedidoInputValidator : AbstractValidator<AtualizarStatusPedidoInput>
{
    public AtualizarStatusPedidoInputValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}