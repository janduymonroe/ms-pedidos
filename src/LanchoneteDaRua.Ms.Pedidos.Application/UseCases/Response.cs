using System.Net;
using System.Text.Json.Serialization;

namespace LanchoneteDaRua.Ms.Pedidos.Application.UseCases;

public class Response
{
    [JsonIgnore]
    public HttpStatusCode? ErrorCode { get; init; }
    [JsonIgnore]
    public string ErrorMessage { get; init; }
    [JsonIgnore]
    public List<string> ErrorMessages { get; init; }
    [JsonIgnore]
    public bool HasError { get => ErrorCode.HasValue; }

}