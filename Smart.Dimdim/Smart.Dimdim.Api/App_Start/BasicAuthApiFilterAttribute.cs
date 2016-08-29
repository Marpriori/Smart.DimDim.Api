using Microsoft.Data.OData;
using Newtonsoft.Json;
using Smart.Dimdim.Api.Controllers;
using Smart.Dimdim.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.OData.Extensions;

namespace Smart.Dimdim.Api.App_Start
{
    public class BasicAuthApiFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                    throw new HttpApiException(HttpStatusCode.Unauthorized, "Cabeçalho 'Authorization' não encontrado.");

                string authToken = actionContext.Request.Headers.Authorization.Scheme;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                string email = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

                var controller = new TokenController();
                controller.Login(email, password);
                base.OnActionExecuting(actionContext);
            }
            catch (HttpApiException ex)
            {
                actionContext.Response = GerarMensagemRetorno(actionContext.Request, ex.StatusCode, ex);
            }
            catch (Exception ex)
            {
                actionContext.Response = GerarMensagemRetorno(actionContext.Request, HttpStatusCode.Unauthorized, ex);

            }

        }
        public static HttpResponseMessage GerarMensagemRetorno(HttpRequestMessage actionContextRequest, HttpStatusCode statusCode, Exception exception)
        {
            var odata = new ODataError
            {
                Message = exception.Message,
                InnerError = new ODataInnerError(exception)
            };
            return
                actionContextRequest.CreateErrorResponse(statusCode, odata);
        }
        
    }
}