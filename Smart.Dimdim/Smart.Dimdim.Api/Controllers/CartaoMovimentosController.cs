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
    builder.EntitySet<CartaoMovimento>("CartaoMovimentos");
    builder.EntitySet<Categoria>("Categorias"); 
    builder.EntitySet<CartaoFatura>("CartaoFaturas"); 
    builder.EntitySet<Usuario>("Usuarios"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CartaoMovimentosController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET: odata/CartaoMovimentos
        [Queryable]
        public IQueryable<CartaoMovimento> GetCartaoMovimentos()
        {
            return db.CartaoMovimentoes;
        }

        // GET: odata/CartaoMovimentos(5)
        [Queryable]
        public SingleResult<CartaoMovimento> GetCartaoMovimento([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoMovimentoes.Where(cartaoMovimento => cartaoMovimento.Id == key));
        }

        // PUT: odata/CartaoMovimentos(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<CartaoMovimento> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CartaoMovimento cartaoMovimento = db.CartaoMovimentoes.Find(key);
            if (cartaoMovimento == null)
            {
                return NotFound();
            }

            patch.Put(cartaoMovimento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoMovimentoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartaoMovimento);
        }

        // POST: odata/CartaoMovimentos
        public IHttpActionResult Post(CartaoMovimento cartaoMovimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartaoMovimentoes.Add(cartaoMovimento);
            db.SaveChanges();

            return Created(cartaoMovimento);
        }

        // PATCH: odata/CartaoMovimentos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<CartaoMovimento> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CartaoMovimento cartaoMovimento = db.CartaoMovimentoes.Find(key);
            if (cartaoMovimento == null)
            {
                return NotFound();
            }

            patch.Patch(cartaoMovimento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoMovimentoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cartaoMovimento);
        }

        // DELETE: odata/CartaoMovimentos(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            CartaoMovimento cartaoMovimento = db.CartaoMovimentoes.Find(key);
            if (cartaoMovimento == null)
            {
                return NotFound();
            }

            db.CartaoMovimentoes.Remove(cartaoMovimento);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CartaoMovimentos(5)/Categoria
        [Queryable]
        public SingleResult<Categoria> GetCategoria([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoMovimentoes.Where(m => m.Id == key).Select(m => m.Categoria));
        }

        // GET: odata/CartaoMovimentos(5)/Fatura
        [Queryable]
        public SingleResult<CartaoFatura> GetFatura([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoMovimentoes.Where(m => m.Id == key).Select(m => m.Fatura));
        }

        // GET: odata/CartaoMovimentos(5)/Owner
        [Queryable]
        public SingleResult<CartaoMovimento> GetOwner([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoMovimentoes.Where(m => m.Id == key).Select(m => m.Owner));
        }

        // GET: odata/CartaoMovimentos(5)/Usuario
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.CartaoMovimentoes.Where(m => m.Id == key).Select(m => m.Usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartaoMovimentoExists(int key)
        {
            return db.CartaoMovimentoes.Count(e => e.Id == key) > 0;
        }
    }
}
