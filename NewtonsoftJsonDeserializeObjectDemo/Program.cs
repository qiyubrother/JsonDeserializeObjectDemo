using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsoftJsonDeserializeObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoData data = new DemoData()
            {
                DemoId = 1,
                Demos = new List<DemoBase>()
                {
                  new DemoA {Id =1, Name="demoA", Type="A", Color="red" },
                  new DemoB {Id =2, Name="democ", Type="B" },
                }
            };

            var j = JsonParser.ToJson(data);

            DemoData nData = new DemoData();
            var o = JsonParser.FromJson<DemoData, DemoBase>(j);
        }
    }
}
