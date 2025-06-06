using SoruxBot.SDK.Plugins.Basic;
using SoruxBot.SDK.Plugins.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoruxBot.SDK.Attribute;
using SoruxBot.SDK.Model.Attribute;
using SoruxBot.SDK.Model.Message;
using SoruxBot.SDK.Plugins.Basic;
using SoruxBot.SDK.Plugins.Model;
using SoruxBot.SDK.Plugins.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
namespace SoruxBot.QQjsonconvert.Plugins;
public class DynamicBinder : ISerializationBinder
{
    private readonly Dictionary<string, Type> _typeMap;

    public DynamicBinder(List<Type> messageentity)
    {
        _typeMap = messageentity.ToDictionary(
            t => $"{t.FullName}, {t.Assembly.GetName().Name}",
            t => t);
    }

    public Type BindToType(string assemblyName, string typeName)
    {
        string fullKey = $"{typeName}, {assemblyName}";
        if (_typeMap.TryGetValue(fullKey, out var type))
        {
            return type;
        }
        return Type.GetType(fullKey);  // fallback
    }

    public void BindToName(Type serializedType, out string assemblyName, out string typeName)
    {
        assemblyName = serializedType.Assembly.GetName().Name;
        typeName = serializedType.FullName;
    }
}
public class QQJsonConverter : IJsonConvert
{
    public string GetTargetPlatform() => "QQ";

    public T DeserializeObject<T>(string value, List<System.Type> messageentity)
    {
        var binder = new DynamicBinder(messageentity);
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All, // 启用类型名称处理
            SerializationBinder = binder
        };
        return JsonConvert.DeserializeObject<T>(value,settings);
    }
}
    


