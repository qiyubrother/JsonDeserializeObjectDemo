using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonsoftJsonDeserializeObjectDemo;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Reflection;

class JsonParser
{
    public static string ToJson(object t) => JsonConvert.SerializeObject(t);

    public static T FromJson<T, R>(string str) => JsonConvert.DeserializeObject<T>(str, new JsonConverter<R>());

}

public abstract class JsonCreationConverter<T> : JsonConverter
{
    protected abstract T Create(Type objectType, JObject jsonObject);
    public override bool CanConvert(Type objectType)
    {
        return typeof(T).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var target = Create(objectType, jsonObject);
        serializer.Populate(jsonObject.CreateReader(), target);
        return target;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

public class JsonConverter<R> : JsonCreationConverter<R>
{
    protected override R Create(Type objectType, JObject jsonObject)
    {
        //var typeName = jsonObject["type"].ToString();
        //switch (typeName)
        //{
        //    case "A":
        //        return new DemoA();
        //    case "B":
        //        return new DemoB();
        //    default: return null;
        //}

        var typeName = jsonObject["type"].ToString();
        Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
        // 依据规则创建类的实例
        dynamic obj = assembly.CreateInstance($"NewtonsoftJsonDeserializeObjectDemo.Demo{typeName}"); // 创建类的实例，返回为 object 类型，需要强制类型转换
        return (R)obj;
    }
}

