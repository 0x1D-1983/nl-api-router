namespace NlApiRouter.Ollama;

using System.Text.Json.Serialization;

public class OllamaChatResponse
{
    [JsonPropertyName("message")]
    public OllamaMessage Message { get; set; } = new OllamaMessage();
}