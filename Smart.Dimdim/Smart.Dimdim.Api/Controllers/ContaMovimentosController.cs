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
    builder.EntitySet<ContaMovimento>("ContaMovimentos");
    builder.EntitySet<Categoria>("Categorias"); 
    builder.EntitySet<Conta>("Contas"); 
    builder.EntitySet<Usuario>("Usuarios"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ContaMovimentosController : ODataController
    {
        private SmartDimdimContext db = new SmartDimdimContext();

        // GET odata/ContaMovimentos
        [Queryable]
        public IQueryable<ContaMovimento> GetContaMovimentos()
        {
            return db.ContaMovimentoes;
        }

        // GET odata/ContaMovimentos(5)
        [Queryable]
        public SingleResult<ContaMovimento> GetContaMovimento([FromODataUri] int key)
        {
            return SingleResult.Create(db.ContaMovimentoes.Where(contamovimento => contamovimento.Id == key));
        }

        // PUT odata/ContaMovimentos(5)
        public IHttpActionResult Put([FromODataUri] int key, ContaMovimento contamovimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != contamovimento.Id)
            {
                return BadRequest();
            }

            db.Entry(contamovimento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaMovimentoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contamovimento);
        }

        // POST odata/ContaMovimentos
        public IHttpActionResult Post(ContaMovimento contamovimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContaMovimentoes.Add(contamovimento);
            db.SaveChanges();

            return Created(contamovimento);
        }

        // PATCH odata/ContaMovimentos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ContaMovimento> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ContaMovimento contamovimento = db.ContaMovimentoes.Find(key);
            if (contamovimento == null)
            {
                return NotFound();
            }

            patch.Patch(contamovimento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaMovimentoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contamovimento);
        }

        // DELETE odata/ContaMovimentos(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ContaMovimento contamovimento = db.ContaMovimentoes.Find(key);
            if (contamovimento == null)
            {
                return NotFound();
            }

            db.ContaMovimentoes.Remove(contamovimento);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/ContaMovimentos(5)/Categoria
        [Queryable]
        public SingleResult<Categoria> GetCategoria([FromODataUri] int key)
        {
            return SingleResult.Create(db.ContaMovimentoes.Where(m => m.Id == key).Select(m => m.Categoria));
        }

        // GET odata/ContaMovimentos(5)/Conta
        [Queryable]
        public SingleResult<Conta> GetConta([FromODataUri] int key)
        {
            return SingleResult.Create(db.ContaMovimentoes.Where(m => m.Id == key).Select(m => m.Conta));
        }

        // GET odata/ContaMovimentos(5)/Owner
        [Queryable]
        public SingleResult<ContaMovimento> GetOwner([FromODataUri] int key)
        {
            return SingleResult.Create(db.ContaMovimentoes.Where(m => m.Id == key).Select(m => m.Owner));
        }

        // GET odata/ContaMovimentos(5)/Usuario
        [Queryable]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.ContaMovimentoes.Where(m => m.Id == key).Select(m => m.Usuario));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContaMovimentoExists(int key)
        {
            return db.ContaMovimentoes.Count(e => e.Id == key) > 0;
        }
    }
}
