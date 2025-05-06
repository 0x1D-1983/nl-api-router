namespace NlApiRouter.Ollama;
using NlApiRouter.AI;
using System.Text.Json;
using System.Net.Http.Json;

/// <summary>
/// Implementation of IOllamaService that uses a local Ollama model to parse queries
/// </summary>
/// <typeparam name="T">The type of object to parse queries into</typeparam>
public class OllamaService<T> : IOllamaService<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public OllamaService(string baseUrl)
    {
        _httpClient = new HttpClient();
        _baseUrl = baseUrl.TrimEnd('/');
    }

    /// <summary>
    /// Parses a query into a structured object using Ollama.
    /// </summary>
    /// <param name="query">The query to parse.</param>
    /// <returns>The parsed object.</returns>
    public async Task<T> ParseQueryAsync(string query)
    {
        var prompt = PromptHelper.GenerateSearchPrompt(query);
        
        var payload = new
        {
            model = "mistral",
            messages = new[] {
                new { role = "user", content = prompt }
            },
            // temperature = 0.1, // Low temperature for more consistent structured output
            // max_tokens = 500,
            stream = false
        };

        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/chat", payload);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();
        var jsonResponse = result?.Message?.Content?.Trim();

        if (string.IsNullOrEmpty(jsonResponse))
        {
            throw new Exception("Failed to get valid response from Ollama");
        }
        
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            IgnoreReadOnlyProperties = true
        };

        return JsonSerializer.Deserialize<T>(jsonResponse, options) ?? 
            throw new Exception("Failed to deserialize Ollama response");
    }
}