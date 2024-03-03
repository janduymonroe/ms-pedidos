﻿using LanchoneteDaRua.Ms.Pedidos.Application.UseCases.AtualizarStatusPedido;
using LanchoneteDaRua.Ms.Pedidos.Infrastructure.MessageBus;
using MediatR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace LanchoneteDaRua.Ms.Pedidos.Infrastructure.HostedService.PagamentosProcessados;

public class SqsHostedService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IMessageBusClient _messageBusClient;
    private readonly IMediator _mediator;
    private bool _disposed;

    public SqsHostedService(IMessageBusClient messageBusClient, IMediator mediator)
    {
        _messageBusClient = messageBusClient;
        _mediator = mediator;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(PollSqsQueue, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private async void PollSqsQueue(object state)
    {
        var queue = "pagamentos-processados";
        
        var messages = await _messageBusClient.ReceiveMessagesAsync(queue);
        
        messages.ForEach(message =>
        {
            var pedido = JsonConvert.DeserializeObject<AtualizarStatusPedidoInput>(message.Body);
            _mediator.Send(pedido);
        });
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _timer?.Dispose();
            }
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}