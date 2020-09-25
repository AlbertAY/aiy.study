using Confluent.Kafka;
using System;

namespace MyKAFKA.Consumer.Client
{
    class Program
    {
        const int cancellationToken = 100000000;

        static void Main(string[] args)
        {
            Console.WriteLine("这里是kafka消费者程序!");

            ThisConsume();

            Console.ReadLine();
        }

        public static void ThisConsume() 
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "192.168.0.7:9092",//
                GroupId = "foo",
                //AutoOffsetReset = AutoOffsetReset.Earliest
            };

            bool cancelled = true;

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                //订阅，topic为 test的
                consumer.Subscribe("test");

                while (cancelled)
                {
                    ConsumeResult<Ignore, string> consumeResult = consumer.Consume(cancellationToken);

                    string msg = $"接收到的值是：{consumeResult.Message.Value}  {DateTime.Now.ToString()}";

                    Console.WriteLine(msg);
                    
                }
                consumer.Close();
            }

        }

    }
}
