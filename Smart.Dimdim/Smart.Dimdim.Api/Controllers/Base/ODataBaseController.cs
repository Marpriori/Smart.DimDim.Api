using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Database;
using System.Web.Http.OData;

namespace Smart.Dimdim.Api.Controllers.Base
{
    [HttpExceptionFilter]
    public class ODataBaseController: ODataController
    {
        protected SmartDimdimContext db = new SmartDimdimContext();
    }
}