namespace ISC.Whitest.Web.Api.Http
{
    public interface IHttpRequestsWithContentBuilder : IHttpRequestBuilder
    {
        IHttpRequestsWithContentBuilder WithContentAsJson(object content, string domainModel = null);
        IHttpRequestsWithContentBuilder WithContentAsPlainText(string content, string domainModel = null);
        
    }
}