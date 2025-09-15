using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Exchange_Example_Api.Data;
using Exchange_Example_Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Exchange_Example_Api.Services;

public class ExchangePricesKafkaConsumerService : BackgroundService
{
    private readonly IConsumer<string, string> _consumer;
    private readonly IServiceScopeFactory _scopeFactory;

    public ExchangePricesKafkaConsumerService(IConfiguration cfg, IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;

        var config = new ConsumerConfig
        {
            BootstrapServers = cfg["Kafka:BootstrapServers"] ?? "kafka:9092",
            GroupId = "exchange-example-db-consumer",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<string, string>(config).Build();
        //_consumer.Subscribe("prices");
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Task.Yield();

        _consumer.Subscribe("prices");

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = _consumer.Consume(cancellationToken);
                    if (result?.Message != null)
                    {
                        var priceChange = JsonSerializer.Deserialize<ExchangePriceChangeModel>(result.Message.Value);
                        if (priceChange != null)
                        {
                            await UpdateStockPriceAsync(priceChange, cancellationToken);
                        }
                    }
                }
                catch (CreateTopicsException e) when (e.Results[0].Error.Code != ErrorCode.UnknownTopicOrPart)
                {
                    throw;
                }
            }
        }
        catch (OperationCanceledException)
        {
            _consumer.Close();
        }
    }

    public override void Dispose()
    {
        _consumer.Close();
        _consumer.Dispose();
        base.Dispose();
    }

    private async Task UpdateStockPriceAsync(ExchangePriceChangeModel priceChange, CancellationToken cancellationToken = default)
    {
        using var scope = _scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var stockExists = await db.Stocks.AnyAsync(stock => stock.Id == priceChange.StockId, cancellationToken);

        if (stockExists)
        {
            await db.Stocks
                .Where(stock => stock.Id == priceChange.StockId)
                .ExecuteUpdateAsync(
                stock => stock.SetProperty(s => s.Price, priceChange.Price),
                cancellationToken);
        }
        else
        {
            await db.Stocks.AddAsync(new Stock
            {
                Ticker = priceChange.Ticker,
                Name = priceChange.StockName,
                Price = priceChange.Price
            }, cancellationToken);
        }

        await db.SaveChangesAsync(cancellationToken);
    }
}
