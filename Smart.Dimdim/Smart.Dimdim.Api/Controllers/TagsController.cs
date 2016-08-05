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
    builder.EntitySet<Tag>("Tags");
    builder.EntitySet<Usuario>("Usuarios"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TagsController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET odata/Tags
        [Queryable]
        public IQueryable<Tag> GetTags()
        {
            return db.Tags;
        }

        // GET odata/Tags(5)
        [Queryable]
        public SingleResult<Tag> GetTag([FromODataUri] int key)
        {
            return SingleResult.Create(db.Tags.Where(tag => tag.Id == key));
        }

        // PUT odata/Tags(5)
        public IHttpActionResult Put([FromODataUri] int key, Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != tag.Id)
            {
                return BadRequest();
            }

            db.Entry(tag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tag);
        }

        // POST odata/Tags
        public IHttpActionResult Post(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tags.Add(tag);
            db.SaveChanges();

            return Created(tag);
        }

        // PATCH odata/Tags(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Tag> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tag tag = db.Tags.Find(key);
            if (tag == null)
            {
                return NotFound();
            }

            patch.Patch(tag);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tag);
        }

        // DELETE odata/Tags(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Tag tag = db.Tags.Find(key);
            if (tag == null)
            {
                return NotFound();
            }

            db.Tags.Remove(tag);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Tags(5)/Usuario
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Tags.Where(m => m.Id == key).Select(m => m.Usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagExists(int key)
        {
            return db.Tags.Count(e => e.Id == key) > 0;
        }
    }
}
