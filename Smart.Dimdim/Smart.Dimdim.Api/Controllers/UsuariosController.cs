using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace Smart.Dimdim.Api.Controllers
{
    public class UsuariosController : EntitySetController<Usuario,int>
    {
        SmartDimdimContext ctx = new SmartDimdimContext();

        [Queryable(PageSize = 10)]
        public override IQueryable<Usuario> Get()
        {
            return ctx.Usuarios.AsQueryable();
        }

        protected override Usuario GetEntityByKey(int key)
        {
            return ctx.Usuarios.Find(key);
        }
    }
}
