using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AssetVariationApi.Utils;

public class JsonUtil
{
    public static T? JsonDeserialize<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter());
    }
}