namespace ISC.Whitest.Web.Api.Serialization
{
    public class PlainTextSerializer : ISerializer
    {
        public string Serialize(object objectToSerialize)
        {
            return objectToSerialize.ToString();
        }
    }
}