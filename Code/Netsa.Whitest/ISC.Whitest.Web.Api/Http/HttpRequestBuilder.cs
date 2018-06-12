using System;
using System.Collections.Generic;
using System.Net.Http;
using ISC.Whitest.Core.Extentions;
using ISC.Whitest.Web.Api.Serialization;

namespace ISC.Whitest.Web.Api.Http
{
    public class HttpRequestBuilder : IHttpRequestsWithContentBuilder
    {
        private HttpMethod _method;
        private Uri _url;
        private object _content;
        private string _domainModel;
        private ContentType _contentType;
        private readonly Dictionary<string, string> _requestHeaders;


        public HttpRequestBuilder()
        {
            this._requestHeaders = new Dictionary<string, string>();
        }

        public IHttpRequestsWithContentBuilder WithPostVerb()
        {
            this._method = HttpMethod.Post;
            return this;
        }

        public IHttpRequestBuilder WithGetVerb()
        {
            this._method = HttpMethod.Get;
            return this;
        }

        public IHttpRequestsWithContentBuilder WithPutVerb()
        {
            this._method = HttpMethod.Put;
            return this;
        }

        public IHttpRequestBuilder WithDeleteVerb()
        {
            this._method = HttpMethod.Delete;
            return this;
        }

        public IHttpRequestBuilder WithUrl(string url)
        {
            this._url = new Uri(url);
            return this;
        }

        public IHttpRequestBuilder WithToken(string tokenValue, TokenType tokenType)
        {
            var authorizationHeader = AuthorizationHeaderFactory.Create(tokenValue, tokenType);
            this._requestHeaders.AddOrUpdate(authorizationHeader);
            return this;
        }

        public IHttpRequestBuilder WithAcceptHeader(string value)
        {
            this._requestHeaders.AddOrUpdate(HttpHeaders.Accept, value);
            return this;
        }

        public IHttpRequestsWithContentBuilder WithContentAsJson(object content, string domainModel = null)
        {
            return WithContent(content, domainModel, ContentType.Json);
        }

        public IHttpRequestsWithContentBuilder WithContentAsPlainText(string content, string domainModel = null)
        {
            return WithContent(content, domainModel, ContentType.PlainText);
        }

        private IHttpRequestsWithContentBuilder WithContent(object content, string domainModel, ContentType contentType)
        {
            this._content = content;
            this._domainModel = domainModel;
            this._contentType = contentType;
            return this;
        }

        public HttpRequestMessage Build()
        {
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = this._method;
            httpRequest.RequestUri = this._url;
            if (HasContent())
            {
                httpRequest.Content = MakeContent();
                httpRequest.Content.Headers.Remove("Content-Type");
                httpRequest.Content.Headers.TryAddWithoutValidation("Content-Type", this._contentType.ToMediaType(_domainModel));
            }

            AddHeadersToRequestHeaders(httpRequest.Headers);

            return httpRequest;
        }

       
        private bool HasContent()
        {
            return this._content != null;
        }
        private HttpContent MakeContent()
        {
            var serializedContent = SerializeContent();
            return new StringContent(serializedContent);
        }
        private string SerializeContent()
        {
            var serializer = SerializerFactory.Create(_contentType);
            var serializedContent = serializer.Serialize(this._content);
            return serializedContent;
        }
        private void AddHeadersToRequestHeaders(System.Net.Http.Headers.HttpHeaders requestHeaders)
        {
            foreach (var header in this._requestHeaders)
            {
                requestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
