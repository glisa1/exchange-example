using Confluent.Kafka;
using System.Text.Json;

namespace Exchange_Example_Api.Services;

public class KafkaProducer(ProducerConfig config)
{
    private readonly IProducer<string, string> _producer = new ProducerBuilder<string, string>(config).Build();

    public async Task PublishAsync<T>(string topic, T payload)
    {
        var json = JsonSerializer.Serialize(payload);
        await _producer.ProduceAsync(topic, new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = json
        });
    }
}
