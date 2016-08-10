using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System.Net;
using System.Web;
using System.Web.Http.OData;

namespace Smart.Dimdim.Api.Controllers.Base
{
    [HttpExceptionFilter]
    [BasicAuthApiFilter]
    public class ODataBaseController: ODataController
    {
        protected SmartDimdimContext db = new SmartDimdimContext();
        public Usuario UsuarioLogado
        {
            get
            {
                var identidade = HttpContext.Current.User.Identity as ApiIdentity;
                if (identidade == null) throw new HttpApiException(HttpStatusCode.Unauthorized, "Usuário não identificado. Fazer login.");

                return identidade.Usuario;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}