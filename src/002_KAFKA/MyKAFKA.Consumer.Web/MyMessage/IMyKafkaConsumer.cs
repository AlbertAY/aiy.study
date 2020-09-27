using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKAFKA.Consumer.Web.MyMessage
{
    interface IMyKafkaConsumer
    {
        void DealMessage(MyKafkaEntity message);
        void Subscribe();
    }

    public class MyKafkaConsumer : IMyKafkaConsumer
    {

        private KafkaConsumer<MyKafkaEntity> consumer { get; set; }

        public MyKafkaConsumer()
        {
            consumer = new KafkaConsumer<MyKafkaEntity>
            {
                Topic = "test",
                ConsumerGroup = "testGroup",
            };
        }

        public void DealMessage(MyKafkaEntity message)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("这是一个消费者!!!" + message.ConsumerValue);
            Console.WriteLine("-------------------------------------------------------------");
        }

        public void Subscribe()
        {
            consumer.Subscribe(DealMessage);
        }
    }
}
