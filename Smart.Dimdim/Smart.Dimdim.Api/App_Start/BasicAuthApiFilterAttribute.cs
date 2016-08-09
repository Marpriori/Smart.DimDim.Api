using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace Smart.Dimdim.Api.App_Start
{
    public class BasicAuthApiFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                    throw new HttpException(HttpStatusCode.Unauthorized, "Cabeçalho 'Authorization' não encontrado.");

                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                string email = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);


                new Token().Login(email, password);
                base.OnActionExecuting(actionContext);
            }
            catch (HttpException ex)
            {
                actionContext.Response = new HttpResponseMessage((HttpStatusCode)ex.WebEventCode);
            }

        }
    }
}