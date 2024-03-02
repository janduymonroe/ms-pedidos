using System.Globalization;
using FluentValidation;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido.InputsAuxiliar;

public class InformacaoDePagamentoInputValidator : AbstractValidator<InformacaoDePagamentoInput>
{
    public InformacaoDePagamentoInputValidator()
    {
        RuleFor(x => x.NumeroDoCartao)
            .NotEmpty()
            .Must(NumeroDoCartaoValido)
            .WithMessage("Número do cartão inválido");

        RuleFor(x => x.NomeCompleto)
            .NotEmpty();

        RuleFor(x => x.DataExpiracao)
            .NotEmpty()
            .Must(DataExpiracaoValida)
            .WithMessage("Cartão expirado");
        
        RuleFor(x => x.Cvv)
            .NotEmpty()
            .Matches(@"^\d+$")
            .WithMessage("O CVV deve conter apenas números.");
    }
    
    private bool NumeroDoCartaoValido(string numeroDoCartao)
    {
        numeroDoCartao = numeroDoCartao.Replace(" ", "");

        if (string.IsNullOrEmpty(numeroDoCartao) || numeroDoCartao.Length < 12 || numeroDoCartao.Length > 19)
            return false;

        return LuhnCheck(numeroDoCartao);
    }

    private bool LuhnCheck(string numeroDoCartao)
    {
        return numeroDoCartao.Reverse()
            .Select(c => c - 48)
            .Select((thisNum, i) => i % 2 == 0
                ? thisNum
                : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
            ).Sum() % 10 == 0;
    }
    
    private bool DataExpiracaoValida(string expiryDate)
    {
        if (DateTime.TryParseExact(expiryDate, "MM/yy", null, DateTimeStyles.None, out DateTime parsedExpiryDate))
        {
            parsedExpiryDate = parsedExpiryDate.AddMonths(1).AddDays(-1);

            return parsedExpiryDate > DateTime.Now;
        }

        return false;
    }
}