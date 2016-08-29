using System.Web.Http;
using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Database;

namespace Smart.Dimdim.Api.Controllers.Base
{
    [HttpExceptionFilter]
    public class ApiBaseController:ApiController
    {
        protected SmartDimdimContext db = new SmartDimdimContext();
    }
}