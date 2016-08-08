using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;

namespace Smart.Dimdim.Api.Controllers
{
  
    public class CategoriasController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET odata/Categorias
        [Queryable]
        public IQueryable<Categoria> GetCategorias()
        {
            return db.Categorias;
        }

        // GET odata/Categorias(5)
        [Queryable]
        public SingleResult<Categoria> GetCategoria([FromODataUri] int key)
        {
            return SingleResult.Create(db.Categorias.Where(categoria => categoria.Id == key));
        }

        // PUT odata/Categorias(5)
        public IHttpActionResult Put([FromODataUri] int key, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != categoria.Id)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(categoria);
        }

        // POST odata/Categorias
        public IHttpActionResult Post(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorias.Add(categoria);
            db.SaveChanges();

            return Created(categoria);
        }

        // PATCH odata/Categorias(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Categoria> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categoria categoria = db.Categorias.Find(key);
            if (categoria == null)
            {
                return NotFound();
            }

            patch.Patch(categoria);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(categoria);
        }

        // DELETE odata/Categorias(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Categoria categoria = db.Categorias.Find(key);
            if (categoria == null)
            {
                return NotFound();
            }

            db.Categorias.Remove(categoria);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Categorias(5)/Usuario
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Categorias.Where(m => m.Id == key).Select(m => m.Usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int key)
        {
            return db.Categorias.Count(e => e.Id == key) > 0;
        }
    }
}
