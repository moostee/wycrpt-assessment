using System.Text.Json.Serialization;

namespace TransactionService.Domain;

public class ServiceResponse
{
    [JsonPropertyName("statusCode")]
    public string StatusCode { get; set; }
    [JsonPropertyName("statusMessage")]
    public string StatusMessage { get; set; }
    [JsonPropertyName("successful")]
    public bool Successful => StatusCode == "00" || StatusCode == "0";
}

public class ServiceResponse<T>
{
    #region properies
    [JsonPropertyName("statusCode")]
    public string StatusCode { get; set; }
    [JsonPropertyName("statusMessage")]
    public string StatusMessage { get; set; }

    [JsonPropertyName("successful")]
    public bool Successful => StatusCode == "00";

    [JsonPropertyName("responseObject")]
    public T ResponseObject { get; private set; } = default;
    #endregion

    public static ServiceResponse<T> Success(T instance, string message = "Successful") => new()
    {
        StatusCode = "00",
        StatusMessage = message,
        ResponseObject = instance
    };
    public static ServiceResponse<T> Failure(string error = "Failed") => new()
    {
        StatusCode = "99",
        StatusMessage = error
    };

}
