using System;

namespace ISC.Whitest.Web.Api.Http
{
    internal static class ContentTypeExtentions
    {
        internal static string ToMediaType(this ContentType contentType, string domainModel)
        {
            var mediaType = GetApplicationMediaType(contentType);
            mediaType = AppendDomainModelToMediaType(mediaType, domainModel);
            return mediaType;
        }

        private static string GetApplicationMediaType(ContentType contentType)
        {
            if (contentType == ContentType.Json) return "application/json";
            if (contentType == ContentType.Xml) return "application/xml";
            if (contentType == ContentType.PlainText) return "text/plain";
            throw new NotSupportedException();
        }
        private static string AppendDomainModelToMediaType(string mediaType, string domainModel)
        {
            if (string.IsNullOrEmpty(domainModel))
                return mediaType;

            return $"{mediaType};domain-model={domainModel}";
        }

    }
}
