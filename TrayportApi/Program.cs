var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/trayport/trades", () =>
{
    var trades = Enumerable.Range(1, 5).Select(index =>
        new Trade("EURUSD", "BUY", 100 * index, 1.23456m))
        .ToArray();
    return trades;
})
.WithName("GetTrades");

app.Run();

record Trade(string Instrument, string Side, int Quantity, decimal Price, string provider = "Trayport");
