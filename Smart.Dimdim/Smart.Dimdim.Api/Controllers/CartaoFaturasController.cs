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
using Smart.Dimdim.Models;

namespace Smart.Dimdim.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Smart.Dimdim.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<CartaoFatura>("CartaoFaturas");
    builder.EntitySet<Cartao>("Cartaos"); 
    builder.EntitySet<Usuario>("Usuarios"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CartaoFaturasController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET: odata/CartaoFaturas
        [Queryable]
        public IQueryable<CartaoFatura> GetCartaoFaturas()
        {
            return db.CartaoFaturas;
        }

        // GET: odata/CartaoFaturas(5)
        [Queryable]
        public SingleResult<CartaoFatura> GetCartaoFatura([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoFaturas.Where(cartaoFatura => cartaoFatura.Id == key));
        }

        // PUT: odata/CartaoFaturas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<CartaoFatura> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CartaoFatura cartaoFatura = db.CartaoFaturas.Find(key);
            if (cartaoFatura == null)
            {
                return NotFound();
            }

            patch.Put(cartaoFatura);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoFaturaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartaoFatura);
        }

        // POST: odata/CartaoFaturas
        public IHttpActionResult Post(CartaoFatura cartaoFatura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartaoFaturas.Add(cartaoFatura);
            db.SaveChanges();

            return Created(cartaoFatura);
        }

        // PATCH: odata/CartaoFaturas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<CartaoFatura> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CartaoFatura cartaoFatura = db.CartaoFaturas.Find(key);
            if (cartaoFatura == null)
            {
                return NotFound();
            }

            patch.Patch(cartaoFatura);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoFaturaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartaoFatura);
        }

        // DELETE: odata/CartaoFaturas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            CartaoFatura cartaoFatura = db.CartaoFaturas.Find(key);
            if (cartaoFatura == null)
            {
                return NotFound();
            }

            db.CartaoFaturas.Remove(cartaoFatura);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CartaoFaturas(5)/Cartao
        [Queryable]
        public SingleResult<Cartao> GetCartao([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoFaturas.Where(m => m.Id == key).Select(m => m.Cartao));
        }

        // GET: odata/CartaoFaturas(5)/Usuario
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoFaturas.Where(m => m.Id == key).Select(m => m.Usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartaoFaturaExists(int key)
        {
            return db.CartaoFaturas.Count(e => e.Id == key) > 0;
        }
    }
}
