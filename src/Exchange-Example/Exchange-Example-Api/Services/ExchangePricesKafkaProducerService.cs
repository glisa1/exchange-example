using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Services;

public class ExchangePricesKafkaProducerService(KafkaProducer producer, IServiceScopeFactory scopeFactory, IConfiguration cfg) : BackgroundService
{
    private readonly KafkaProducer _producer = producer;
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    private readonly IConfiguration config = cfg;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await CreateTopic();

        var rnd = new Random();

        while (!cancellationToken.IsCancellationRequested)
        {
            var stocks = await GetAllStocks(cancellationToken);

            var tasks = stocks.Select(stock =>
            {
                var newPrice = GetRandomPriceChange(stock.Price, rnd);
                var priceChange = new ExchangePriceChangeModel(stock.Id, stock.Ticker, stock.Name, newPrice);
                return _producer.PublishAsync("prices", priceChange);
            }).ToList();

            await Task.WhenAll(tasks);

            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        }
    }

    private async Task<List<Stock>> GetAllStocks(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        return await db.Stocks.ToListAsync(cancellationToken);
    }

    private static double GetRandomPriceChange(double currentPrice, Random rnd)
    {
        // Change price by -5% to +5%
        var changePercent = (rnd.NextDouble() * 10) - 5;
        return currentPrice + (currentPrice * changePercent / 100);
    }

    private async Task CreateTopic()
    {
        using var adminClient = new AdminClientBuilder(
            new AdminClientConfig
            {
                BootstrapServers = config["Kafka:BootstrapServers"] ?? "kafka:9092"
            }).Build();

        try
        {
            await adminClient.CreateTopicsAsync(
            [
                new() {
                    Name = "prices",
                    NumPartitions = 1,
                    ReplicationFactor = 1
                }
            ]);
        }
        catch (CreateTopicsException e) when (e.Results[0].Error.Code == ErrorCode.TopicAlreadyExists)
        {
            // Topic already exists
        }
    }
}
