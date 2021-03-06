﻿using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKAFKA.Consumer.Web.MyMessage
{
    public class KafkaConsumer<T> where T : KafkaMessage
    {
        public string Topic { get; set; }
        public string ConsumerGroup { get; set; }

        public void Subscribe(Action<T> dealMessage)
        {
            var config = new ConsumerConfig
            {
                GroupId = ConsumerGroup,
                BootstrapServers = "192.168.0.7:9092",
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            Task.Run(() =>
            {
                var builder = new ConsumerBuilder<string, string>(config);
                using (var consumer = builder.Build())
                {
                    consumer.Subscribe(Topic);
                    while (true)
                    {
                        var result = consumer.Consume();
                        try
                        {
                            var message = JsonConvert.DeserializeObject<T>(result.Message.Value);
                            dealMessage(message);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Topic : {result.Topic}, Message : {result.Message.Value}");
                        }
                    }
                }
            });
        }
    }
}
