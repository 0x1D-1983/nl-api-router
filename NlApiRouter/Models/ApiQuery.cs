namespace NlApiRouter.Models;

/// <summary>
/// Represents a structured API query parsed from natural language.
/// </summary>
public class ApiQuery
{
    /// <summary>
    /// The name of the API to be called.
    /// </summary>
    public string Api { get; set; } = string.Empty;

    /// <summary>
    /// The parameters to be passed to the API.
    /// </summary>
    public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
}
