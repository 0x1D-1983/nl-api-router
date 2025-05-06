using NlApiRouter.Models;

namespace NlApiRouter.Services;

/// <summary>
/// Dispatches API requests to the appropriate handler based on the parsed query.
/// </summary>
public class ApiDispatcher
{
    private readonly Dictionary<string, IApiHandler> _handlers;

    /// <summary>
    /// Initializes the ApiDispatcher with a list of API handlers.
    /// </summary>
    /// <param name="handlers">List of API handlers to be used for dispatching requests.</param>
    public ApiDispatcher(IEnumerable<IApiHandler> handlers)
    {
        _handlers = handlers.ToDictionary(h => h.ApiName, h => h);
    }

    /// <summary>
    /// Dispatches the API request to the appropriate handler based on the parsed query.
    /// </summary>
    /// <param name="query">The parsed API query object.</param>
    /// <returns>String representation of the API response.</returns>
    public async Task<string> DispatchAsync(ApiQuery query)
    {
        if (_handlers.TryGetValue(query.Api, out var handler))
        {
            return await handler.CallApiAsync(query.Params);
        }

        throw new InvalidOperationException($"No handler registered for API: {query.Api}");
    }
}
