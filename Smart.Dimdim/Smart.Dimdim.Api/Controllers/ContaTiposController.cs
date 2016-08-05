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
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Smart.Dimdim.Api.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ContaTipo>("ContaTipos");
    builder.EntitySet<Usuario>("Usuarios"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ContaTiposController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET odata/ContaTipos
        [Queryable]
        public IQueryable<ContaTipo> GetContaTipos()
        {
            return db.ContaTipoes;
        }

        // GET odata/ContaTipos(5)
        [Queryable]
        public SingleResult<ContaTipo> GetContaTipo([FromODataUri] int key)
        {
            return SingleResult.Create(db.ContaTipoes.Where(contatipo => contatipo.Id == key));
        }

        // PUT odata/ContaTipos(5)
        public IHttpActionResult Put([FromODataUri] int key, ContaTipo contatipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != contatipo.Id)
            {
                return BadRequest();
            }

            db.Entry(contatipo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaTipoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contatipo);
        }

        // POST odata/ContaTipos
        public IHttpActionResult Post(ContaTipo contatipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContaTipoes.Add(contatipo);
            db.SaveChanges();

            return Created(contatipo);
        }

        // PATCH odata/ContaTipos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ContaTipo> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ContaTipo contatipo = db.ContaTipoes.Find(key);
            if (contatipo == null)
            {
                return NotFound();
            }

            patch.Patch(contatipo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaTipoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contatipo);
        }

        // DELETE odata/ContaTipos(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ContaTipo contatipo = db.ContaTipoes.Find(key);
            if (contatipo == null)
            {
                return NotFound();
            }

            db.ContaTipoes.Remove(contatipo);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/ContaTipos(5)/Usuario
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.ContaTipoes.Where(m => m.Id == key).Select(m => m.Usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContaTipoExists(int key)
        {
            return db.ContaTipoes.Count(e => e.Id == key) > 0;
        }
    }
}
