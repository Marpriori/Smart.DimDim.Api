using System.Web.Http;
using Smart.Dimdim.Api.App_Start;

namespace Smart.Dimdim.Api.Controllers.Base
{
    [HttpExceptionFilter]
    public class ApiBaseController:ApiController
    {
    }
}