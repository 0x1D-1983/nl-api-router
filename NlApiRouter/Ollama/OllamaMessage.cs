namespace NlApiRouter.Ollama;

using System.Text.Json.Serialization;

public class OllamaMessage
{
    [JsonPropertyName("role")]
    public string Role { get; set; } = "user";

    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}