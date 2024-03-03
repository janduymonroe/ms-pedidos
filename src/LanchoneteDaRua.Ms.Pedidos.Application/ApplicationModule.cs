using System.Diagnostics.CodeAnalysis;
using LanchoneteDaRua.Ms.Pedidos.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace LanchoneteDaRua.Ms.Pedidos.Application;

[ExcludeFromCodeCoverage]
public static class ApplicationModule
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(AbstractHandler<,>).Assembly);
        });
        
        return services;
    }
}