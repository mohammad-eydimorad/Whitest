using Newtonsoft.Json;

namespace ISC.Whitest.Web.Api.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}