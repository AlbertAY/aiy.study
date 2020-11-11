using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNumberCount
{
    class Program
    {
        static string path = String.Empty;
        static void Main(string[] args)
        {
            login:
            try
            {

                if (String.IsNullOrEmpty(path))
                {
                    Console.Write("请输入json的绝对路径（回车确定）：");

                    path = Console.ReadLine();
                }                

                if (!File.Exists(path))
                {
                    Console.WriteLine("输入的路径错误!");
                    path = String.Empty;
                    goto login;
                }                

                StringBuilder build = new StringBuilder();

                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        build.Append(str);
                    }
                }
                string json = build.ToString();

                if (String.IsNullOrEmpty(json))
                {
                    Console.WriteLine("Json 获取失败！");
                }
                else
                {                  
                    dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(json);

                    Console.WriteLine("Json数组的数据量是：" + jsonObj?.Count);

                    jsonObj = null;
                    System.GC.Collect();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }


            Console.WriteLine("键入数字1，并回车可以重新计算数量");

            string line = Console.ReadLine();
            if (line.Equals("1"))
            {
                goto login;
            }
        }
    }
}
