using System;
using System.Net;
using System.Web;

namespace Smart.Dimdim.Api.App_Start
{
    public class HttpApiException : HttpException
    {
        public HttpApiException(HttpStatusCode statusCode) : 
            this(statusCode, "Erro")
        {
        }

        public HttpApiException(HttpStatusCode statusCode, string message)
            : base(Convert.ToInt32(statusCode), message)
        {
        }
    }
}