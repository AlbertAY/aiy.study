using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKAFKA.Consumer.Web.MyMessage
{
    public class MyKafkaEntity: KafkaMessage
    {
        public string ConsumerValue { set; get; }
    }
}
