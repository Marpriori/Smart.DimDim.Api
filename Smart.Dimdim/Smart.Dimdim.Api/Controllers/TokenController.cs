using Smart.Dimdim.Api.App_Start;
using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;

namespace Smart.Dimdim.Api.Controllers
{

    public class TokenController : ODataBaseController
    {

        // GET odata/Usuarios
        [Queryable]
        public IQueryable<Token> GetToken()
        {
            var tokenList = new List<Token>();
            try
            {
                var usuario = ((ApiIdentity)HttpContext.Current.User.Identity).Usuario;

                tokenList.Add(new Token(usuario));
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return tokenList.AsQueryable();

        }

        // GET odata/Usuarios(5)
        [Queryable]
        public SingleResult<Token> Login([FromODataUri] string email, string senha)
        {
            var token = new Token();
            token.Login(email, senha);
            return new SingleResult<Token>((new List<Token> { token }).AsQueryable());
        }

        // POST odata/Token
        public IHttpActionResult Post(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            usuario.Senha = Usuario.Crypto(usuario.Senha);
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return Created(usuario);
        }

        // PATCH odata/Usuarios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Usuario> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = db.Usuarios.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            patch.Patch(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(usuario);
        }

        // DELETE odata/Usuarios(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Usuario usuario = db.Usuarios.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int key)
        {
            return db.Usuarios.Any(e => e.Id == key);
        }
    }
}
