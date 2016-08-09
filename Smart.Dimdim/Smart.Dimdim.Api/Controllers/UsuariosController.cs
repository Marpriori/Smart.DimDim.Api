using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using Smart.Dimdim.Api.Controllers.Base;

namespace Smart.Dimdim.Api.Controllers
{

    public class UsuariosController : ODataBaseController
    {

        // GET odata/Usuarios
        [Queryable]
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET odata/Usuarios(5)
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Usuarios.Where(usuario => usuario.Id == key));
        }

        // PUT odata/Usuarios(5)
        public IHttpActionResult Put([FromODataUri] int key, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != usuario.Id)
            {
                return BadRequest();
            }
            
            db.Entry(usuario).State = EntityState.Modified;

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

        // POST odata/Usuarios
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
