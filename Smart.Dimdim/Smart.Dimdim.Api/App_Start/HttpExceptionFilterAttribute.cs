using System.Net.Http;
using System.Web.Http.Filters;

namespace Smart.Dimdim.Api.App_Start
{
    public class HttpExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is HttpApiException)
            {
                var exception = actionExecutedContext.Exception as HttpApiException;
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    StatusCode = exception.StatusCode,
                    Content = new StringContent(exception.Message, System.Text.Encoding.UTF8, "text/plain"),
                };
            }
                base.OnException(actionExecutedContext);

        }
    }
}