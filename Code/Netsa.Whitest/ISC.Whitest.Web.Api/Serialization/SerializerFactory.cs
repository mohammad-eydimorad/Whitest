using System;
using ISC.Whitest.Web.Api.Http;

namespace ISC.Whitest.Web.Api.Serialization
{
    public static class SerializerFactory
    {
        public static ISerializer Create(ContentType contentType)
        {
            if (contentType == ContentType.Json) return new JsonSerializer();
            if (contentType == ContentType.PlainText) return new PlainTextSerializer();
            throw new NotSupportedException();
        }
    }
}