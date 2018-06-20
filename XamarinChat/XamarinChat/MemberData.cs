using Newtonsoft.Json;

namespace XamarinChat
{
    [JsonObject(MemberSerialization.Fields)]
    public class MemberData
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("color")]
        public string Color;
    }
}