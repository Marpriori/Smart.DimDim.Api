using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Smart.Dimdim.Api.App_Start
{
    public class HttpExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            if (actionExecutedContext.Exception is HttpApiException)
            {
                var exception = actionExecutedContext.Exception as HttpApiException;
                statusCode = exception.StatusCode;
            }

            actionExecutedContext.Response =
               BasicAuthApiFilterAttribute.GerarMensagemRetorno(
                   actionExecutedContext.Request,
                   statusCode,
                   actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);

        }
    }
}