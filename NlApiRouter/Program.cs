using NlApiRouter.Ollama;
using NlApiRouter.Models;
using NlApiRouter.Services;
using Microsoft.Extensions.DependencyInjection;

var ollamaService = new OllamaService<ApiQuery>("http://localhost:11434");
var services = new ServiceCollection();
services.AddSingleton(ollamaService);
services.AddHttpClient<TrayportTradesHandler>();
services.AddHttpClient<EpexTradesHandler>();
services.AddSingleton<IApiHandler, TrayportTradesHandler>();
services.AddSingleton<IApiHandler, EpexTradesHandler>();
services.AddSingleton<ApiDispatcher>();

var serviceProvider = services.BuildServiceProvider();
var apiDispatcher = serviceProvider.GetRequiredService<ApiDispatcher>();

var query = "I want to know the price of Epex trades gas data for yesterday";

var queryObject = await ollamaService.ParseQueryAsync(query);

// Console.WriteLine(queryObject);

var result = await apiDispatcher.DispatchAsync(queryObject);
Console.WriteLine(result);