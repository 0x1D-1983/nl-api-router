namespace NlApiRouter.Services;

/// <summary>
/// Handles requests to the Trayport trades API.
/// </summary>
public class TrayportTradesHandler : IApiHandler
{
    public string ApiName => "getTrayportTrades";

    private readonly HttpClient _httpClient;

    public TrayportTradesHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Calls the Trayport trades API with the provided parameters.
    /// </summary>
    /// <param name="parameters">Dictionary of parameters to pass to the API.</param>
    /// <returns>String representation of the API response.</returns>
    public async Task<string> CallApiAsync(Dictionary<string, string> parameters)
    {
        var query = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
        var url = $"http://localhost:5224/trayport/trades?{query}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
