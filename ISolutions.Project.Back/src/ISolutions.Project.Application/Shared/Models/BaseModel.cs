using ISolutions.Project.Domain.Enums;
using System.Text.Json.Serialization;

namespace ISolutions.Project.Application.Shared.Models;
public class BaseModel
{
    [JsonIgnore]
    public bool Success { get; set; }

    [JsonIgnore]
    public IList<string>? Errors { get; set; }

    [JsonIgnore]
    public ResponseType ResponseType { get; set; }

    public BaseModel()
    {
        Errors = new List<string>();
        Success = true;
    }

    public void SetResponse(string message, ResponseType responseType)
    {
        Errors?.Add(message);
        ResponseType = responseType;
    }
}
