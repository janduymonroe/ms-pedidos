namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases.CriarPedido;

public class CriarPedidoOutput : Response
{
    public CriarPedidoOutput()
    {
        
    }
    public CriarPedidoOutput(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}