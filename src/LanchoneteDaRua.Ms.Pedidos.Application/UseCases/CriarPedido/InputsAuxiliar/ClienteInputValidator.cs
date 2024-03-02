using FluentValidation;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido.InputsAuxiliar;

public class ClienteInputValidator : AbstractValidator<ClienteInput>
{
    public ClienteInputValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.NomeCompleto)
            .NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}