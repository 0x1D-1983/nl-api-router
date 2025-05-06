namespace NlApiRouter.Services;

public interface IApiHandler
{
    string ApiName { get; }
    Task<string> CallApiAsync(Dictionary<string, string> parameters);
}
