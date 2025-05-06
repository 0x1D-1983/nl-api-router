using System.Text.Json;

namespace NlApiRouter.Ollama;

/// <summary>
/// Interface for interacting with a local Ollama language model to parse natural language into structured objects
/// </summary>
/// <typeparam name="T">The type of object to parse the natural language into</typeparam>
public interface IOllamaService<T> where T : class
{
    /// <summary>
    /// Converts a natural language query into a structured object using the Ollama LLM
    /// </summary>
    /// <param name="query">The natural language query to parse</param>
    /// <returns>A structured object of type T parsed from the query</returns>
    Task<T> ParseQueryAsync(string query);
}