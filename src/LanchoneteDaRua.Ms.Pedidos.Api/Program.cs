using System.Diagnostics.CodeAnalysis;
using LanchoneteDaRua.Ms.Pedidos.Api;
using LanchoneteDaRua.Ms.Pedidos.Application;
using LanchoneteDaRua.Ms.Pedidos.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.UseInlineDefinitionsForEnums();
});
builder.Services.AddApiLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddInfraestructureLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program
{
    private Program() { }
}

