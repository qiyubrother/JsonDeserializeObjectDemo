using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewtonsoftJsonDeserializeObjectDemo
{

    class DemoData
    {
        [JsonProperty("demoId")]
        public int DemoId { get; set; }

        [JsonProperty("demos")]
        public List<DemoBase> Demos { get; set; }
    }

    public class DemoBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class DemoA : DemoBase
    {
        [JsonProperty("color")]
        public string Color { get; set; }

    }

    public class DemoB : DemoBase
    {
        [JsonProperty("size")]
        public double[] Size { get; set; }
    }
}