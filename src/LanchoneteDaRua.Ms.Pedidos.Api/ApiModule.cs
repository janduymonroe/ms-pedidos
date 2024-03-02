using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido;

namespace LanchoneteDaRua.Ms.Pedidos.Api;

[ExcludeFromCodeCoverage]
public static class ApiModule
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        
        services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(typeof(PedidoInputValidator).Assembly);
        return services;
    }
}