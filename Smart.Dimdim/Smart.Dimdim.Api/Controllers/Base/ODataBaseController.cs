using Smart.Dimdim.Api.Database;
using System.Web.Http.OData;

namespace Smart.Dimdim.Api.Controllers
{
    public class ODataBaseController: ODataController
    {
        protected SmartDimdimContext db = new SmartDimdimContext();
    }
}