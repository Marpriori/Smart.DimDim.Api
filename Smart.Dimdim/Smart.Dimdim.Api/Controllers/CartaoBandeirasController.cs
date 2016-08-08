using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Smart.Dimdim.Api.Database;
using Smart.Dimdim.Api.Models;

namespace Smart.Dimdim.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Smart.Dimdim.Api.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<CartaoBandeira>("CartaoBandeiras");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CartaoBandeirasController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET: odata/CartaoBandeiras
        [Queryable]
        public IQueryable<CartaoBandeira> GetCartaoBandeiras()
        {
            return db.CartaoBandeiras;
        }

        // GET: odata/CartaoBandeiras(5)
        [Queryable]
        public SingleResult<CartaoBandeira> GetCartaoBandeira([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoBandeiras.Where(cartaoBandeira => cartaoBandeira.Id == key));
        }

        // PUT: odata/CartaoBandeiras(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<CartaoBandeira> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CartaoBandeira cartaoBandeira = db.CartaoBandeiras.Find(key);
            if (cartaoBandeira == null)
            {
                return NotFound();
            }

            patch.Put(cartaoBandeira);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoBandeiraExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartaoBandeira);
        }

        // POST: odata/CartaoBandeiras
        public IHttpActionResult Post(CartaoBandeira cartaoBandeira)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartaoBandeiras.Add(cartaoBandeira);
            db.SaveChanges();

            return Created(cartaoBandeira);
        }

        // PATCH: odata/CartaoBandeiras(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<CartaoBandeira> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CartaoBandeira cartaoBandeira = db.CartaoBandeiras.Find(key);
            if (cartaoBandeira == null)
            {
                return NotFound();
            }

            patch.Patch(cartaoBandeira);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoBandeiraExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartaoBandeira);
        }

        // DELETE: odata/CartaoBandeiras(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            CartaoBandeira cartaoBandeira = db.CartaoBandeiras.Find(key);
            if (cartaoBandeira == null)
            {
                return NotFound();
            }

            db.CartaoBandeiras.Remove(cartaoBandeira);
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

        private bool CartaoBandeiraExists(int key)
        {
            return db.CartaoBandeiras.Count(e => e.Id == key) > 0;
        }
    }
}
