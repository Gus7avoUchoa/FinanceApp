using System.Text.Json.Serialization;

namespace FinanceApp.Core.Responses;

public class Response<TData>
{
    private int _statusCode = Configuration.DefaultStatusCode;    

    public string? Message { get; set; }
    public TData? Data { get; set; }
    
    [JsonIgnore]
    public bool IsSuccess => _statusCode is >= 200 and <= 299;

    [JsonConstructor]
    public Response() => _statusCode = Configuration.DefaultStatusCode;

    public Response(
        TData? data,
        int statusCode = Configuration.DefaultStatusCode,
        string? message = null) {
            Data = data;
            _statusCode = statusCode;
            Message = message;
        }
}