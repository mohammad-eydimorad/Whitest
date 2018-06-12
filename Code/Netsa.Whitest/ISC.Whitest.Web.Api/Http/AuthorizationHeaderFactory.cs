using System;
using System.Collections.Generic;

namespace ISC.Whitest.Web.Api.Http
{
    internal static class AuthorizationHeaderFactory
    {
        internal static KeyValuePair<string,string> Create(string tokenValue, TokenType tokenType)
        {
            var value = GetHeaderValue(tokenValue, tokenType);
            return new KeyValuePair<string, string>(HttpHeaders.Authorization, value);
        }

        private static string GetHeaderValue(string tokenValue, TokenType tokenType)
        {
            var tokenTypeName = GetTokenTypeName(tokenType);
            return $"{tokenTypeName} {tokenValue}";
        }

        private static object GetTokenTypeName(TokenType tokenType)
        {
            if (tokenType == TokenType.Bearer) return "Bearer";
            if (tokenType == TokenType.Jwt) return "JWT";
            throw new NotImplementedException();
        }
    }
}