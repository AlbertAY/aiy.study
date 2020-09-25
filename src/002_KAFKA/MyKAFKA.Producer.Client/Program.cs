using Confluent.Kafka;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MyKAFKA.Producer.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("这里是Kafka生产者程序!");

            Task.Run(() =>
            {
                Send();
            });            

            Console.ReadLine();
        }


        public static async void Send()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "192.168.0.7:9092",//可以配置多个集群，逗号分隔
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                while (true)
                {
                    Thread.Sleep(5000);

                    string msg = $"a log message {DateTime.Now.ToString()}";

                    //发送topic为test的
                    await producer.ProduceAsync("test", new Message<string, string> { Key = "test", Value = msg });

                    Console.WriteLine($"发送的消息是 {msg}");
                }
                
            }
        }
    }
}
