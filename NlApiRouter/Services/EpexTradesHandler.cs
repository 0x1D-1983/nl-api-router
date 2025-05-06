namespace NlApiRouter.Services;

/// <summary>
/// Handles requests to the Epex trades API.
/// </summary>
public class EpexTradesHandler : IApiHandler
{
    public string ApiName => "getEpexTrades";

    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes the EpexTradesHandler with the provided HTTP client.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for API requests.</param>
    public EpexTradesHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Calls the Epex trades API with the provided parameters.
    /// </summary>
    /// <param name="parameters">Dictionary of parameters to pass to the API.</param>
    /// <returns>String representation of the API response.</returns>
    public async Task<string> CallApiAsync(Dictionary<string, string> parameters)
    {
        var query = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
        var url = $"http://localhost:5042/epex/trades?{query}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
